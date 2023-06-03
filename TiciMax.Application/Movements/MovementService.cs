using AutoMapper;
using Newtonsoft.Json;
using ServiceStack.Redis;
using TiciMax.Application.Base;
using TiciMax.Application.Contracts.MessageBroker;
using TiciMax.Application.Contracts.Movements;
using TiciMax.Domain.Movements;
using TiciMax.Domain.Shared.Movements;
using TiciMax.Domain.Shared.MovementReports;
using TiciMax.Application.Contracts.CacheServices;

namespace TiciMax.Application.Movements
{
	public class MovementService : Service<Movement>, IMovementService
	{
		private readonly IConsumer _consumer;
		private readonly IPublisher _publisher;
		private readonly ICacheServices _cacheServices;

		public MovementService(IMovementRepository repository, IMapper mapper, IConsumer consumer, IPublisher publisher,
			ICacheServices cacheServices) : base(repository, mapper)
		{
			_consumer = consumer;
			_publisher = publisher;
			_cacheServices = cacheServices;
		}

		public async Task<MovementDto> AddAsync(MovementCreateDto input, MovementType movementType)
		{
			var entity = _mapper.Map<Movement>(input);
			entity.MovementType = movementType;
			await AddAsync(entity);

			var queueName = "CreateReport" + entity.Id;
			_publisher.Publish(queueName, JsonConvert.SerializeObject(entity));
			_consumer.MovementRepoertConsum(queueName);

			var result = _mapper.Map<MovementDto>(entity);
			_cacheServices.Remove(MovementReportConst.MovementReportRedisKey);
			return result;
		}

		public async Task<MovementDto> GetAsync(int id)
		{
			var entity = await GetByIdAsync(id);
			return _mapper.Map<MovementDto>(entity);
		}

		public async Task<List<MovementDto>> GetAsync(int? personId = null, long? dateStart = null, long? dateEnd = null)
		{
			DateTime? startDate = dateStart.HasValue ? DateTimeOffset.FromUnixTimeSeconds(dateStart.Value).UtcDateTime : null;
			DateTime? endDate = dateEnd.HasValue ? DateTimeOffset.FromUnixTimeSeconds(dateEnd.Value).UtcDateTime : null; ;
			var result = await WhereAsync(a => (!personId.HasValue || a.UserId == personId.Value) &&
				(!startDate.HasValue || a.Time >= startDate) &&
				(!endDate.HasValue || a.Time <= endDate));
			return _mapper.Map<List<MovementDto>>(result);
		}

		public async Task<List<MovementDto>> GetReportAsync(int? personId = null, long? dateStart = null, long? dateEnd = null)
		{
			List<MovementDto> result;

			if (!_cacheServices.ContainsKey(MovementReportConst.MovementReportRedisKey))
			{
				result = await GetAsync(personId, dateStart, dateEnd);
				_cacheServices.Set<List<MovementDto>>(MovementReportConst.MovementReportRedisKey, result);
			}
			else
			{
				result = _cacheServices.Get<List<MovementDto>>(MovementReportConst.MovementReportRedisKey);
			}

			result.Where(a => (!personId.HasValue || a.UserId == personId.Value) &&
				(!dateStart.HasValue || a.Time >= dateStart) &&
				(!dateEnd.HasValue || a.Time <= dateEnd));
			return result;
		}
	}
}

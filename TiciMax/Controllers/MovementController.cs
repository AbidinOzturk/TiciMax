using Microsoft.AspNetCore.Mvc;
using TiciMax.Application.Contracts.Movements;
using TiciMax.Domain.Shared.Movements;

namespace TiciMax.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MovementController : ControllerBase
	{
		IMovementService _movementService;

		public MovementController(IMovementService movementService)
        {
			_movementService = movementService;
		}

        [HttpPost]
		[Route("enter")]
		public async Task<MovementDto> EnterAsync(MovementCreateDto input)
		{
			var result= await _movementService.AddAsync(input, MovementType.Entry);
			return result;
		}

		[HttpPost]
		[Route("exit")]
		public async Task<MovementDto> ExitAsync(MovementCreateDto input)
		{
			var result = await _movementService.AddAsync(input ,MovementType.Exit);
			return result;
		}

		[HttpGet]
		[Route("{id}")]
		public async virtual Task<MovementDto> GetAsync(int id)
		{
			return await _movementService.GetAsync(id);
		}


		[HttpGet]
		public async virtual Task<List<MovementDto>> GetPersonelMovementAsync(int? personId=null, long? dateStart=null, long? dateEnd=null)
		{
			return await _movementService.GetAsync(personId,dateStart,dateEnd);
		}

		[HttpGet]
		[Route("reports")]
		public async virtual Task<List<MovementDto>> GetReportAsync(int? personId = null, long? dateStart = null, long? dateEnd = null)
		{
			return await _movementService.GetReportAsync(personId, dateStart, dateEnd);
		}
	}
}

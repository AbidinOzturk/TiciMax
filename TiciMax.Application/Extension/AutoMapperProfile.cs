using AutoMapper;
using TiciMax.Application.Contracts.Movements;
using TiciMax.Domain.Movements;

namespace TiciMax.Application.Extension
{
	public class AutoMapperProfile : Profile
	{

		public AutoMapperProfile()
		{
			CreateMap<Movement, MovementCreateDto>()
				.ForMember(d => d.Time, opt => opt.MapFrom(s =>  ((DateTimeOffset)s.Time).ToUnixTimeSeconds()));
			CreateMap<Movement, MovementDto>()
				.ForMember(d => d.Time, opt => opt.MapFrom(s => ((DateTimeOffset)s.Time).ToUnixTimeSeconds()));
			CreateMap<MovementCreateDto,Movement>()
				.ForMember(d => d.Time, opt => opt.MapFrom(s => DateTimeOffset.FromUnixTimeSeconds(s.Time).UtcDateTime));
			CreateMap<MovementDto,Movement >()
				.ForMember(d => d.Time, opt => opt.MapFrom(s => DateTimeOffset.FromUnixTimeSeconds(s.Time).UtcDateTime));
		}
	}
}

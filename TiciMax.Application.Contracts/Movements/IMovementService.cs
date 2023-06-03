using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiciMax.Application.Contracts.Base;
using TiciMax.Domain.Movements;
using TiciMax.Domain.Shared.Movements;

namespace TiciMax.Application.Contracts.Movements
{
	public interface IMovementService : IService<Movement>
	{
		Task<MovementDto> AddAsync(MovementCreateDto input, MovementType movementType);
		Task<MovementDto> GetAsync(int id);
		Task<List<MovementDto>> GetAsync(int? personId = null, long? dateStart = null, long? dateEnd = null);
		Task<List<MovementDto>> GetReportAsync(int? personId = null, long? dateStart = null, long? dateEnd = null);
	}
}

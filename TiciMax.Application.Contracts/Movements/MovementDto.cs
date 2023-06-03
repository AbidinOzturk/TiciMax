using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiciMax.Domain.Shared.Movements;

namespace TiciMax.Application.Contracts.Movements
{
	public class MovementDto
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public MovementType MovementType { get; set; }
		public long Time { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiciMax.Domain.Shared.Movements;

namespace TiciMax.Domain.Movements
{
	public class Movement
	{
        public int Id { get; set; }
		public int UserId { get; set; }
		public MovementType MovementType { get; set; }
		public DateTime Time { get; set; }
	}
}

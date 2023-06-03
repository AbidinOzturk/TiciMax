using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiciMax.Domain.Shared.Movements;

namespace TiciMax.Application.Contracts.Movements
{
	public class MovementCreateDto
	{
		public int UserId { get; set; }
		public long Time { get; set; }
       
    }
}

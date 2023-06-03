using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiciMax.Domain.Movements;
using TiciMax.EntityFrameworkCore.EntityFrameworkCore;

namespace TiciMax.EntityFrameworkCore.Movements
{
	public class MovementRepository:Repository<Movement>,IMovementRepository
	{
		public MovementRepository(AppDbContext dbcontext) : base(dbcontext)
		{

		}
	}
}

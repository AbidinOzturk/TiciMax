using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiciMax.Domain.MovementReports;
using TiciMax.Domain.Movements;
using TiciMax.EntityFrameworkCore.EntityFrameworkCore;

namespace TiciMax.EntityFrameworkCore.MovementReports
{
	public class MovementReportRepository: Repository<MovementReport>, IMovementReportRepository
	{
		public MovementReportRepository(AppDbContext dbcontext) : base(dbcontext)
		{

		}
	}
}

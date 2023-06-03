using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiciMax.Domain.MovementReports;
using TiciMax.Domain.Movements;

namespace TiciMax.EntityFrameworkCore.MovementReports
{
	public static class MovementReportModelBuilderExtensions
	{
		public static void ConfigureMovementReport([NotNull] this ModelBuilder builder)
		{
			builder.Entity<MovementReport>(b =>
			{
				b.Property(a => a.Id).UseIdentityColumn();
			});
		}
	}
}

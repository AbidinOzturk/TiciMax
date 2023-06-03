using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiciMax.Domain.Movements;

namespace TiciMax.EntityFrameworkCore.Movements
{
	public static class MovementModelBuilderExtensions
	{
		public static void ConfigureMovement([NotNull] this ModelBuilder builder)
		{
			builder.Entity<Movement>(b =>
			{
				b.Property(a => a.Id).UseIdentityColumn();
			});
		}
	}
}

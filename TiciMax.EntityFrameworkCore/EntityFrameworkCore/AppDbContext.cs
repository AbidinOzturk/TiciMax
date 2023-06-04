using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TiciMax.Domain.MovementReports;
using TiciMax.Domain.Movements;
using TiciMax.EntityFrameworkCore.MovementReports;
using TiciMax.EntityFrameworkCore.Movements;

namespace TiciMax.EntityFrameworkCore.EntityFrameworkCore
{
	public  class AppDbContext: DbContext
	{
		IConfiguration _configuration;

		public AppDbContext(IConfiguration configuration)
        {
			_configuration = configuration;
		}
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql(_configuration.GetSection("ConnectionStrings:ConStr").Value);
			base.OnConfiguring(optionsBuilder);
		}

		public DbSet<Movement> Movements { get; set; }
		public DbSet<MovementReport> MovementReports { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.ConfigureMovement();
			builder.ConfigureMovementReport();
		}
	}
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TiciMax.Application.Contracts.CacheServices;
using TiciMax.Application.Contracts.MessageBroker;
using TiciMax.Application.Contracts.Movements;
using TiciMax.Application.Movements;
using TiciMax.Application.RabbitMQ;
using TiciMax.Application.Redis;
using TiciMax.Domain.MovementReports;
using TiciMax.Domain.Movements;
using TiciMax.EntityFrameworkCore.EntityFrameworkCore;
using TiciMax.EntityFrameworkCore.MovementReports;
using TiciMax.EntityFrameworkCore.Movements;

namespace TiciMax.Application.Extension
{
	public static class Dependencies
	{
		public static void AddDependencies(this IServiceCollection services)
		{
			services.AddScoped<DbContext, AppDbContext>();
			services.AddDbContext<AppDbContext>();

			services.AddScoped<IMovementReportRepository, MovementReportRepository>();


			services.AddScoped<IMovementRepository, MovementRepository>();
			services.AddScoped<IMovementService, MovementService>();

			services.AddScoped<IConsumer, RabbitMQConsumer>();
			services.AddScoped<IPublisher, RabbitMQPublisher>();

			services.AddScoped<ICacheServices, AppRedisClientService>();

		}
	}
}

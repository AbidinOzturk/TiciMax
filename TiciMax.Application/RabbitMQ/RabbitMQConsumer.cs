using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using TiciMax.Application.Contracts.MessageBroker;
using TiciMax.Domain.MovementReports;
using TiciMax.Domain.Movements;
using TiciMax.Domain.Shared.Movements;
using TiciMax.EntityFrameworkCore.EntityFrameworkCore;

namespace TiciMax.Application.RabbitMQ
{
	public class RabbitMQConsumer : IConsumer
	{

		private readonly RabbitMQService _rabbitMQService;
		private readonly IConfiguration _configuration;

		public RabbitMQConsumer(IConfiguration configuration)
		{
			_rabbitMQService = new RabbitMQService(configuration);
			_configuration = configuration;
		}

		public void MovementRepoertConsum(string queueName)
		{
			var connection = _rabbitMQService.GetRabbitMQConnection();

			var channel = connection.CreateModel();

			var consumer = new AsyncEventingBasicConsumer(channel);
			// Received event'i sürekli listen modunda olacaktır.
			consumer.Received += async (model, ea) =>
			{

				var message = Encoding.UTF8.GetString(ea.Body.Span);

				var movement = JsonConvert.DeserializeObject<Movement>(message);

				if (movement != null)
				{
					bool update = true;

					using (AppDbContext context = new AppDbContext(_configuration))
					{

						var report = await context.MovementReports.FirstOrDefaultAsync(a => a.UserId == movement.UserId && a.Day == movement.Time.Date);
						if (report == null)
						{
							report = new MovementReport();
							update = false;
						}

						report.UserId = movement.UserId;
						report.Day = movement.Time.Date;
						if (movement.MovementType == MovementType.Entry && (report.EntryTime == null || movement.Time < report.EntryTime)) report.EntryTime = movement.Time;
						else if (movement.MovementType == MovementType.Exit && (report.ExitTime == null || movement.Time > report.ExitTime)) report.ExitTime = movement.Time;

						if (report.EntryTime != null && report.ExitTime != null)
						{
							report.Duration = report.ExitTime.Value.Subtract(report.EntryTime.Value);
							report.DurationStr = String.Format(@"{0:%h} saat {0:%m} dk.{0:%s} sn.", report.Duration);
						}
						if (update) context.Set<MovementReport>().Update(report);
						else await context.Set<MovementReport>().AddAsync(report);
						await context.SaveChangesAsync();
					}
				}

				await Task.Yield();
			};

			channel.BasicConsume(queueName, false, consumer);

		}
	}

	public class Deneme
	{
		public Deneme()
		{

		}
	}
}

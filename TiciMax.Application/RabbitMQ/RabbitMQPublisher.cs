using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiciMax.Application.Contracts.MessageBroker;

namespace TiciMax.Application.RabbitMQ
{
	public class RabbitMQPublisher : IPublisher
	{
		private readonly RabbitMQService _rabbitMQService;
		public RabbitMQPublisher(IConfiguration configuration)
        {
			_rabbitMQService = new RabbitMQService(configuration);
		}
        public void Publish(string queueName, string message)
		{

			using (var connection = _rabbitMQService.GetRabbitMQConnection())
			{
				using (var channel = connection.CreateModel())
				{
					channel.QueueDeclare(queueName, false, false, false, null);

					channel.BasicPublish("", queueName, null, Encoding.UTF8.GetBytes(message));
				}
			}
		}
	}
}

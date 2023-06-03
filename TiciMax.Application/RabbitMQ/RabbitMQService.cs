using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiciMax.Application.RabbitMQ
{
	public class RabbitMQService
	{
		private readonly IConfiguration _configuration;

		public RabbitMQService(IConfiguration configuration)
        {
            _configuration=configuration;
		}

        public IConnection GetRabbitMQConnection()
		{
			string? _hostName= _configuration.GetSection("RabbitMQService:HostName").Value;
			string? _userName = _configuration.GetSection("RabbitMQService:UserName").Value;
			string? _password = _configuration.GetSection("RabbitMQService:Password").Value;

			ConnectionFactory connectionFactory = new ConnectionFactory()
			{
				HostName = _hostName,
				UserName = _userName,
				Password = _password,
				DispatchConsumersAsync = true
			};

			return connectionFactory.CreateConnection();
		}
	}
}

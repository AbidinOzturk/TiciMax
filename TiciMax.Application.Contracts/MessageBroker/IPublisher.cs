using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiciMax.Application.Contracts.MessageBroker
{
	public interface IPublisher
	{
		void Publish(string queueName, string message);
	}
}

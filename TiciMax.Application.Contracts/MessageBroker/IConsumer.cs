using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiciMax.Application.Contracts.MessageBroker
{
	public interface IConsumer
	{
		void MovementRepoertConsum(string queueName);
	}
}

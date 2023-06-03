using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiciMax.Application.Contracts.CacheServices
{
	public  interface ICacheServices
	{
		bool ContainsKey(string key);
		bool Set<T>(string key, T value);
		T Get<T>(string key);
		bool Remove(string key);
	}
}

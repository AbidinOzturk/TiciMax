using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiciMax.Application.Contracts.CacheServices;

namespace TiciMax.Application.Redis
{
	public class AppRedisClientService: ICacheServices
	{
		
		private readonly RedisClient redisClient;
		private readonly IConfiguration _configuration;
		public AppRedisClientService(IConfiguration configuration) 
		{
			_configuration = configuration;
			string _hostName = _configuration.GetSection("RedisService:HostName").Value+"";
			int _port = int.Parse(_configuration.GetSection("RedisService:Port").Value+"");
			redisClient = new RedisClient(_hostName,_port);
		}

		public bool ContainsKey(string key)
		{
			return redisClient.ContainsKey(key);
		}

		public bool Set<T>(string key, T value)
		{
			return redisClient.Set<T>(key, value);
		}

		public T Get<T>(string key)
		{
			return redisClient.Get<T>(key);
		}

		public bool Remove(string key) 
		{
			if (redisClient.ContainsKey(key)) return redisClient.Remove(key);
			else return true;
		}
	}
}

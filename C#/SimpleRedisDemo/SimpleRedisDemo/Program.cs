﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Linq;

namespace SimpleRedisDemo
{
    class Program
    {
        private static IConfigurationRoot Configuration { get; set; }
        const string SecretName = "CacheConnection";

        private static void InitializeConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<Program>();

            Configuration = builder.Build();
        }

        private static readonly Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            string cacheConnection = Configuration[SecretName];
            return ConnectionMultiplexer.Connect(cacheConnection);
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }

        static void Main(string[] args)
        {
            InitializeConfiguration();

            IDatabase cache = lazyConnection.Value.GetDatabase();

            var redisKeys = Connection.GetServer(Configuration["ServerDetails"]).Keys(0, "*");
            string[] keys = redisKeys.Select(key => (string)key).ToArray();

            foreach(var key in keys)
            {
                Console.WriteLine($"Key: {key} :: Value: {cache.StringGet(key).ToString()}" );
            }

            // Simple PING command
            string cacheCommand = "PING";
            Console.WriteLine("\nCache command  : " + cacheCommand);
            Console.WriteLine("Cache response : " + cache.Execute(cacheCommand).ToString());

            // Simple get and put of integral data types into the cache
            cacheCommand = "GET Shiva";
            Console.WriteLine("\nCache command  : " + cacheCommand + " or StringGet()");
            Console.WriteLine("Cache response : " + cache.StringGet("Shiva").ToString());

            var person = new { Id = Guid.NewGuid(), Name = "Shiva Sai", Age = 25 };
            cache.StringSet(person.Id.ToString(), JsonConvert.SerializeObject(person));

            Console.WriteLine("\n\nPress any key ...");
            Console.ReadKey();
            
        }
    }
}

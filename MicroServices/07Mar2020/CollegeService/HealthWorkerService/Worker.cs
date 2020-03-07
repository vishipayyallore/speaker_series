using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using College.Service.Protos;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HealthWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _config;
        private AddressBookService.AddressBookServiceClient _client;
        private Random random;

        public Worker(ILogger<Worker> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;

            random = new Random();
        }

        protected AddressBookService.AddressBookServiceClient Client
        {
            get
            {
                if (_client == null)
                {
                    var channel = GrpcChannel.ForAddress(_config["RPCService:ServiceUrl"]);
                    _client = new AddressBookService.AddressBookServiceClient(channel);
                }
                return _client;
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var customerName = _config["RPCService:CustomerName"];

                var healthData = new HealthRequest { Name = customerName, HealthParameter1 = GetRandomValue(), HealthParameter2 = GetRandomValue() };

                var results = await Client.AddPersonHealthDataAsync(healthData);
                Console.WriteLine($"Person Health Data: {results.Message}");

                await Task.Delay(_config.GetValue<int>("RPCService:DelayInterval"), stoppingToken);
            }
        }


        private int GetRandomValue()
        {
            return random.Next(1, 100);
        }
    }
}

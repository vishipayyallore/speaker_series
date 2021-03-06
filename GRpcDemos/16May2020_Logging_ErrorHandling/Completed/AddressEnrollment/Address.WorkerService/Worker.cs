using Address.Common;
using Address.Server.Protos;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Address.Server.Protos.AddressBookServer;

namespace Address.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _config;
        private AddressBookServerClient _client;
        private ILoggerFactory _loggerFactory;
        Random _random;

        public Worker(ILogger<Worker> logger, IConfiguration config,
            ILoggerFactory loggerFactory)
        {
            _logger = logger;
            _config = config;

            _loggerFactory = loggerFactory;

            _random = new Random();
        }

        protected AddressBookServerClient Client
        {
            get
            {
                if (_client == null)
                {
                    var channel = GrpcChannel.ForAddress(_config["RPCService:ServiceUrl"],
                                new GrpcChannelOptions { LoggerFactory = _loggerFactory });
                    _client = new AddressBookServerClient(channel);
                }
                return _client;
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var userAddress = new AddressAdditionRequest
                {
                    Name = Utilities.GenerateName(Utilities.GetRandomValue()),
                    Address = Utilities.GenerateAddress(),
                    Enrollment = Utilities.EnrollmentTypes[Utilities.GetRandomValue(1, 4)]
                };

                try
                {
                    var results = await Client.AddUserAddressAsync(userAddress);

                    Console.WriteLine($"Address Data: {results.Message}");
                }
                catch(RpcException rpcError)
                {
                    _logger.LogError($"Error received from Server. {rpcError.Message} {rpcError.Trailers}");
                }

                await Task.Delay(_config.GetValue<int>("RPCService:DelayInterval"), stoppingToken);
            }
        }

    }
}


//private string GenerateName(int len)
//{
//    StringBuilder name = new StringBuilder(50);

//    string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
//    string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };


//    name.Append(consonants[_random.Next(consonants.Length)].ToUpper());
//    name.Append(vowels[_random.Next(vowels.Length)]);
//    int b = 2;
//    while (b < len)
//    {
//        name.Append(consonants[_random.Next(consonants.Length)]);
//        b++;
//        name.Append(vowels[_random.Next(vowels.Length)]);
//        b++;
//    }

//    return name.ToString();
//}

//private int GetRandomValue()
//{
//    return _random.Next(8, 17);
//}

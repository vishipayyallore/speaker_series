using Address.Server;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using static Address.Server.Greeter;

namespace Address.ConsoleApp
{
    class Program
    {
        static private GreeterClient _client;
        private static IConfiguration _config;

        static protected GreeterClient Client
        {
            get
            {
                if (_client == null)
                {
                    var channel = GrpcChannel.ForAddress(_config["RPCService:ServiceUrl"]);
                    _client = new GreeterClient(channel);
                }
                return _client;
            }
        }

        static async Task Main(string[] args)
        {
            _config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json").Build();

            var helloRequest = new HelloRequest { Name = _config["RPCService:CustomerName"] };
            var helloResults = await Client.SayHelloAsync(helloRequest);
            Console.WriteLine($"Hello Response: {helloResults.Message}");

            Console.WriteLine("\n\nPress any key ...");
            Console.ReadKey();
        }
    }
}

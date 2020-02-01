using College.Service.Protos;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace CollegeService.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new AddressBookService.AddressBookServiceClient(channel);

            var userAddress = new AddressAdditionRequest { Name = "BDotNet", Address = "MSFT 25-Jan-2020" };

            var reply = await client.AddUserAddressAsync(userAddress);

            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }
    }
}

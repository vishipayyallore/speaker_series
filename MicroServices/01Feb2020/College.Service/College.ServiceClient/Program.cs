using College.Service.Protos;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace College.ServiceClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new AddressBookService.AddressBookServiceClient(channel);

            var userAddress = new AddressAdditionRequest { Name = "Manish", Address = "New Address" };

            var reply = await client.AddUserAddressAsync(userAddress);

            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

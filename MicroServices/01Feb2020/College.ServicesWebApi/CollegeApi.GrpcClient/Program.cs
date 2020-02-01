using College.Api.Protos;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace CollegeApi.GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new CollegeService.CollegeServiceClient(channel);

            var professorRequest = new GetProfessorRequest { ProfessorId = "5ec797ec-da0a-43df-b3a3-3f9a04163656" };

            var professor = await client.GetProfessorByIdAsync(professorRequest);

            Console.WriteLine($"{professor.Name} {professor.Salary} {professor.Teaches}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

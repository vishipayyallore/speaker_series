using College.Services.Protos;
using Google.Protobuf.WellKnownTypes;
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

            // Retrieve Single Row
            var professorRequest = new GetProfessorRequest { ProfessorId = "5ec797ec-da0a-43df-b3a3-3f9a04163656" };
            var professor = await client.GetProfessorByIdAsync(professorRequest);
            DisplayProfessorDetails(professor);

            // Retrieve Multiple Rows
            var professors = await client.GetAllProfessorsAsync(new Empty());
            foreach (var prof in professors.Professors)
            {
                DisplayProfessorDetails(prof);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void DisplayProfessorDetails(GetProfessorResponse professor)
        {
            Console.WriteLine($"{professor.Name} {professor.Salary} {professor.Teaches} {professor.Doj}");
        }

    }
}

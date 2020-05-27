using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Simple.CosmosDbDemo
{
    class Program
    {
        private static IConfiguration _config;

        static async Task Main(string[] args)
        {
            _config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            string databaseName = _config["CosmosDbConnection:DatabaseName"];
            string containerName = _config["CosmosDbConnection:ContainerName"];

            CosmosClient client = await InitializeCosmosClientInstanceAsync().ConfigureAwait(false);

            DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
            await database.Database.CreateContainerIfNotExistsAsync(containerName, "/id");

            Console.WriteLine("\n\nPress any key ...");
            Console.ReadKey();
        }

        private static async Task<CosmosClient> InitializeCosmosClientInstanceAsync()
        {

            string account = _config["CosmosDbConnection:Account"];
            string key = _config["CosmosDbConnection:Key"];

            CosmosClientBuilder clientBuilder = new CosmosClientBuilder(account, key);
            CosmosClient client = clientBuilder
            .WithConnectionModeDirect()
            .Build();

            return await Task.FromResult(client);
        }

    }
}

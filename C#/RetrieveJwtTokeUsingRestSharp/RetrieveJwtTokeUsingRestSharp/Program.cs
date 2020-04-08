using System;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace RetrieveJwtTokeUsingRestSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("http://localhost:50460");
            var request = new RestRequest("/api/auth/token", Method.POST);

            request.AddJsonBody(new
            {
                username = "userone",
                password = "abcd123"
            });

            IRestResponse response = client.Execute(request);
            var content = response.Content; // {"message":" created."}

            UserAuthorization userAuthorization = JsonConvert.DeserializeObject<UserAuthorization>(content);
            Console.WriteLine($"Token: {userAuthorization.Token} \nExpiration: {userAuthorization.Expiration}");

            Console.WriteLine("\n\nPress any key ...");
            Console.ReadKey();
        }
    }
}

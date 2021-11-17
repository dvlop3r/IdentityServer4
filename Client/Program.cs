using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }


            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "client",
                ClientSecret = "secret",
                Scope = "api1"
            });
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

                        var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);
            var apiResponse = await apiClient.GetAsync("https://localhost:6001/identity");
            if (!apiResponse.IsSuccessStatusCode)
                Console.WriteLine(apiResponse.StatusCode);
            else
            {
                var content = await apiResponse.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
        }
    }
}

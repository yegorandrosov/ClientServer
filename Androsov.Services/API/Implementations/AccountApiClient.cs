using Androsov.API.Responses;
using Androsov.Services.API.Interfaces;
using Androsov.Services.API.Models;
using Androsov.Services.API.Models.Requests;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Androsov.Services.API.Implementations
{
    public class AccountApiClient : IAccountApiClient
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly BasicApiClientAuthentication basicApiClientAuthentication;

        public AccountApiClient(IHttpClientFactory httpClientFactory, BasicApiClientAuthentication basicApiClientAuthentication)
        {
            this.httpClientFactory = httpClientFactory;
            this.basicApiClientAuthentication = basicApiClientAuthentication;
        }

        public async Task<AuthResponse> Login()
        {
            using var httpClient = httpClientFactory.CreateClient("api");

            var httpResponse = await httpClient.PostAsJsonAsync("/api/v1/account/login", new AuthRequest()
            {
                Username = basicApiClientAuthentication.Username,
                Password = basicApiClientAuthentication.Password,
            });

            httpResponse.EnsureSuccessStatusCode();

            var body = await httpResponse.Content.ReadAsStringAsync();
            var authResponse = JsonConvert.DeserializeObject<AuthResponse>(body);

            return authResponse!;
        }
    }
}

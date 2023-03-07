using Androsov.Services.API.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Androsov.Services.API.Implementations
{
    internal class UsersApiClient : IUsersApiClient
    {
        private readonly IApiClient apiClient;
        private readonly IConfiguration configuration;
        private readonly string username;

        public UsersApiClient(IApiClient apiClient, IConfiguration configuration, string username)
        {
            this.apiClient = apiClient;
            this.configuration = configuration;
            this.username = username;
        }

        public IMessageApiClient Messages => new MessageApiClient(this);

        public HttpClient GetHttpClient()
        {
            var httpClient = apiClient.CreateHttpClient();
            var url = configuration.GetValue<string>("API:Url");

            httpClient.BaseAddress = new Uri($"{url}/api/v1/users/{username}/");

            return httpClient;
        }
    }
}

using Androsov.Services.API.Interfaces;

namespace Androsov.Services.API.Implementations
{
    internal class UsersApiClient : IUsersApiClient
    {
        private readonly IApiClient apiClient;
        private readonly string username;

        public UsersApiClient(IApiClient apiClient, string username)
        {
            this.apiClient = apiClient;
            this.username = username;
        }

        public IMessageApiClient Messages => new MessageApiClient(this);

        public HttpClient GetHttpClient()
        {
            var httpClient = apiClient.CreateHttpClient();

            httpClient.BaseAddress = new Uri($"http://localhost:5000/api/v1/users/{username}/");

            return httpClient;
        }
    }
}

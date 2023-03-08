using Androsov.Services.API.Interfaces;

namespace Androsov.Services.API.Implementations
{
    public class UsersApiHttpClientFactory : IUsersApiHttpClientFactory
    {
        private readonly IAuthenticatedApiHttpClientFactory apiHttpClientFactory;

        public UsersApiHttpClientFactory(IAuthenticatedApiHttpClientFactory apiHttpClientFactory)
        {
            this.apiHttpClientFactory = apiHttpClientFactory;
        }

        public async Task<HttpClient> CreateHttpClient(string username)
        {
            var httpClient = await apiHttpClientFactory.CreateHttpClient();

            httpClient.BaseAddress = new Uri(httpClient.BaseAddress!, $"/api/v1/users/{username}/");

            return httpClient;
        }
    }
}

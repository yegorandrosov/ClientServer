using Androsov.Services.API.Interfaces;
using Androsov.Services.API.Models;

namespace Androsov.Services.API.Implementations
{
    internal class ApiClient : IApiClient
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly BasicApiClientAuthentication clientAuthentication;

        public ApiClient(IHttpClientFactory httpClientFactory, BasicApiClientAuthentication clientAuthentication)
        {
            this.httpClientFactory = httpClientFactory;
            this.clientAuthentication = clientAuthentication;
        }

        public IUsersApiClient Me => new UsersApiClient(this, clientAuthentication.Username);

        public IUsersApiClientFactory Users => new UsersApiClientFactory(this);

        public HttpClient CreateHttpClient()
        {
            var httpClient = httpClientFactory.CreateClient("api");

            return httpClient;
        }
    }
}

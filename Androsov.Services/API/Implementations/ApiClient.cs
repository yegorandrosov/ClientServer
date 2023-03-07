using Androsov.Services.API.Interfaces;
using Androsov.Services.API.Models;
using Microsoft.Extensions.Configuration;

namespace Androsov.Services.API.Implementations
{
    internal class ApiClient : IApiClient
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly BasicApiClientAuthentication clientAuthentication;

        public ApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, BasicApiClientAuthentication clientAuthentication)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.clientAuthentication = clientAuthentication;
        }

        public IUsersApiClient Me => new UsersApiClient(this, configuration, clientAuthentication.Username);

        public IUsersApiClientFactory Users => new UsersApiClientFactory(this, configuration);

        public HttpClient CreateHttpClient()
        {
            var httpClient = httpClientFactory.CreateClient("api");

            return httpClient;
        }
    }
}

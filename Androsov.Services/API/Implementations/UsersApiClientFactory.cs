using Androsov.Services.API.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Androsov.Services.API.Implementations
{
    internal class UsersApiClientFactory : IUsersApiClientFactory
    {
        private readonly IApiClient apiClient;
        private readonly IConfiguration configuration;

        public UsersApiClientFactory(IApiClient apiClient, IConfiguration configuration)
        {
            this.apiClient = apiClient;
            this.configuration = configuration;
        }

        public IUsersApiClient this[string username] => new UsersApiClient(apiClient, configuration, username);
    }
}

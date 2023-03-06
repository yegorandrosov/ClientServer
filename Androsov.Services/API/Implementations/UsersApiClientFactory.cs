using Androsov.Services.API.Interfaces;

namespace Androsov.Services.API.Implementations
{
    internal class UsersApiClientFactory : IUsersApiClientFactory
    {
        private readonly IApiClient apiClient;

        public UsersApiClientFactory(IApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public IUsersApiClient this[string username] => new UsersApiClient(apiClient, username);
    }
}

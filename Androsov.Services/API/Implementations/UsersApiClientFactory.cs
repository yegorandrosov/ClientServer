using Androsov.Services.API.Interfaces;

namespace Androsov.Services.API.Implementations
{
    internal class UsersApiClientFactory : IUsersApiClientFactory
    {
        private readonly IUsersApiHttpClientFactory usersApiHttpClientFactory;

        public UsersApiClientFactory(IUsersApiHttpClientFactory usersApiHttpClientFactory)
        {
            this.usersApiHttpClientFactory = usersApiHttpClientFactory;
        }

        public IUsersApiClient Create(string username)
        {
            return new UsersApiClient(usersApiHttpClientFactory, username);
        }
    }
}

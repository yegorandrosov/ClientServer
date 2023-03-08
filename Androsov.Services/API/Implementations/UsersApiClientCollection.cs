using Androsov.Services.API.Interfaces;

namespace Androsov.Services.API.Implementations
{
    internal class UsersApiClientCollection : IUsersApiClientCollection
    {
        private readonly IUsersApiClientFactory usersApiClientFactory;

        public UsersApiClientCollection(IUsersApiClientFactory usersApiClientFactory)
        {
            this.usersApiClientFactory = usersApiClientFactory;
        }

        public IUsersApiClient this[string username] => usersApiClientFactory.Create(username);
    }
}

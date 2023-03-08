using Androsov.Services.API.Interfaces;
using Androsov.Services.API.Models;

namespace Androsov.Services.API.Implementations
{
    internal class ApiClient : IApiClient
    {
        private readonly BasicApiClientAuthentication clientAuthentication;
        private readonly IUsersApiClientFactory usersApiClientFactory;
        private readonly IUsersApiClientCollection usersApiClientCollection;

        public ApiClient(BasicApiClientAuthentication clientAuthentication,
            IUsersApiClientFactory usersApiClientFactory,
            IUsersApiClientCollection usersApiClientCollection)
        {
            this.clientAuthentication = clientAuthentication;
            this.usersApiClientFactory = usersApiClientFactory;
            this.usersApiClientCollection = usersApiClientCollection;
        }

        public IUsersApiClient Me => usersApiClientFactory.Create(clientAuthentication.Username);

        public IUsersApiClientCollection Users => usersApiClientCollection;
    }
}

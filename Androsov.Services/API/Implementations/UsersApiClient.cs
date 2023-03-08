using Androsov.Services.API.Interfaces;

namespace Androsov.Services.API.Implementations
{
    internal class UsersApiClient : IUsersApiClient
    {
        private readonly IUsersApiHttpClientFactory apiHttpClientFactory;
        private string username = null!;

        public UsersApiClient(IUsersApiHttpClientFactory apiHttpClientFactory, string username)
        {
            this.apiHttpClientFactory = apiHttpClientFactory;
            this.username = username;
        }

        public IMessageApiClient Messages => new MessageApiClient(() => apiHttpClientFactory.CreateHttpClient(username));
    }
}

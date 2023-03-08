namespace Androsov.Services.API.Interfaces
{
    public interface IUsersApiHttpClientFactory
    {
        public Task<HttpClient> CreateHttpClient(string username);
    }
}

namespace Androsov.Services.API.Interfaces
{
    public interface IAuthenticatedApiHttpClientFactory
    {
        public Task<HttpClient> CreateHttpClient();
    }
}

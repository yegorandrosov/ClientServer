using Androsov.Services.API.Interfaces;
using Androsov.Services.Authentication;
using System.Net.Http.Headers;

namespace Androsov.Services.API.Implementations
{
    public class AuthenticatedApiHttpClientFactory : IAuthenticatedApiHttpClientFactory
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ITokenProvider tokenProvider;

        public AuthenticatedApiHttpClientFactory(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
        {
            this.httpClientFactory = httpClientFactory;
            this.tokenProvider = tokenProvider;
        }

        public async Task<HttpClient> CreateHttpClient()
        {
            var httpClient = httpClientFactory.CreateClient("api");

            var authToken = await tokenProvider.GetToken();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

            return httpClient;
        }
    }
}

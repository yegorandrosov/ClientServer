using Androsov.Services.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Androsov.Services.API
{
    internal class ApiClient : IApiClient
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ApiClient(IHttpClientFactory httpClientFactory, string username, string password)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public IAuthenticatedApiClient Me => throw new NotImplementedException();

        public IAuthenticateApiClientFactory Users => throw new NotImplementedException();

        public HttpClient GetHttpClient()
        {
            var httpClient = httpClientFactory.CreateClient("api");

            return httpClient;
        }
    }
}

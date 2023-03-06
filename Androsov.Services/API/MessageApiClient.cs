using Androsov.Services.API.Interfaces;
using Androsov.Services.API.Responses;

namespace Androsov.Services.API
{
    internal class MessageApiClient : IMessageApiClient
    {
        private readonly IApiClient apiClient;

        public MessageApiClient(IApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Task Set(string message)
        {
            return Task.CompletedTask;
        }

        public Task<GetMessageResponse> Get()
        {
            return Task.FromResult(new GetMessageResponse());
        }
    }
}

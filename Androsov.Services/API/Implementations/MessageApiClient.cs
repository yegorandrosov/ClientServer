using Androsov.Services.API.Interfaces;
using Androsov.Services.API.Models.Responses;
using System.Text;
using Newtonsoft.Json;

namespace Androsov.Services.API
{
    internal class MessageApiClient : IMessageApiClient
    {
        private readonly IUsersApiClient apiClient;

        public MessageApiClient(IUsersApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task Set(string message)
        {
            using var httpClient = apiClient.GetHttpClient();

            var body = JsonConvert.SerializeObject(new { text = message });
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            // todo: add retry policy
            var response = await httpClient.PostAsync("messages", content);

            response.EnsureSuccessStatusCode();
        }

        public async Task<GetMessageResponse> Get()
        {
            using var httpClient = apiClient.GetHttpClient();

            var response = await httpClient.GetAsync("messages");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<GetMessageResponse>(content);

            return responseObj!;
        }
    }
}

using Androsov.Services.API.Interfaces;
using Androsov.Services.API.Models.Responses;
using System.Text;
using Newtonsoft.Json;

namespace Androsov.Services.API
{
    internal class MessageApiClient : IMessageApiClient
    {
        private readonly Func<Task<HttpClient>> httpClientFactory;

        public MessageApiClient(Func<Task<HttpClient>> httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task Set(string message)
        {
            using var httpClient = await httpClientFactory();

            var body = JsonConvert.SerializeObject(new { text = message });
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            // todo: add retry policy
            var response = await httpClient.PostAsync("messages", content);

            response.EnsureSuccessStatusCode();
        }

        public async Task<GetMessageResponse> Get()
        {
            using var httpClient = await httpClientFactory();

            var response = await httpClient.GetAsync("messages");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var responseObj = JsonConvert.DeserializeObject<GetMessageResponse>(content);

            return responseObj!;
        }
    }
}

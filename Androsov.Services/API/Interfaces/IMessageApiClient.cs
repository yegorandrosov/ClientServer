using Androsov.Services.API.Models.Responses;

namespace Androsov.Services.API.Interfaces
{
    public interface IMessageApiClient
    {
        public Task Set(string message);

        public Task<GetMessageResponse> Get();
    }
}

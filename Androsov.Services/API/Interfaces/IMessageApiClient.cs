using Androsov.Services.API.Responses;

namespace Androsov.Services.API.Interfaces
{
    public interface IMessageApiClient
    {
        /// <summary>
        /// Send the message
        /// </summary>
        /// <param name="message">Message</param>
        public Task Set(string message);

        /// <summary>
        /// Get last message posted
        /// </summary>
        /// <returns>Last text posted by the user</returns>
        public Task<GetMessageResponse> Get();
    }
}

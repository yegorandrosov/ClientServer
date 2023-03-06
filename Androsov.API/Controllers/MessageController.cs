using Androsov.API.Models;
using Androsov.DataAccess.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Androsov.API.Controllers
{
    //[Authorize]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository messageRepository;

        public MessageController(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        [HttpPost]
        [Route("api/v1/users/{username}/messages")]
        public async Task<IActionResult> Post(string username, SetTextRequestModel model)
        {
            await messageRepository.Set(username, model.Text!);

            return Ok();
        }

        [HttpGet]
        [Route("api/v1/users/{username}/messages")]
        public async Task<IActionResult> Get(string username)
        {
            var text = await messageRepository.Get(username);

            return new JsonResult(new
            {
                Text = text
            });
        }
    }
}
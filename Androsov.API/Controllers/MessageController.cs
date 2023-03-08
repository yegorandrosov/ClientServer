using Androsov.API.Requests;
using Androsov.DataAccess.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Androsov.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/v1/users")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository messageRepository;

        public MessageController(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        [HttpPost]
        [Route("{username}/messages")]
        public async Task<IActionResult> Post(string username, SetTextRequest model)
        {
            await messageRepository.Set(username, model.Text!);

            return Ok();
        }

        [HttpGet]
        [Route("{username}/messages")]
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
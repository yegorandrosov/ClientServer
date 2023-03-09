using Androsov.API.Requests;
using Androsov.DataAccess.Entities;
using Androsov.DataAccess.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Androsov.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/v1/users")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository messageRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public MessageController(IMessageRepository messageRepository, UserManager<ApplicationUser> userManager)
        {
            this.messageRepository = messageRepository;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("{username}/messages")]
        public async Task<IActionResult> Post(string username, SetTextRequest model)
        {
            if (User!.Identity!.Name != username)
                return BadRequest("Wrong user");

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
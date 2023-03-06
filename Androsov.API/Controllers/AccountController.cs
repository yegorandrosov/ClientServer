using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Androsov.API.Controllers
{
    [Route("api/v1/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(string username)
        {
            return Ok();
        }
    }
}

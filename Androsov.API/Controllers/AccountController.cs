using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Androsov.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IActionResult Login(string username)
        {
            return Ok();
        }
    }
}

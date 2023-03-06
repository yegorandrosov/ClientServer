using Androsov.Services.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Androsov.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiClient apiClient;

        public HomeController(IApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SetWebText(string text)
        {
            await apiClient.Me.Messages.Set(text);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetDesktopText()
        {
            var response = await apiClient.Users["Desktop"].Messages.Get();

            return Ok(response);
        }
    }
}

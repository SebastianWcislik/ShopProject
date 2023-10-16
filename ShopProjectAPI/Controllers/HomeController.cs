using Microsoft.AspNetCore.Mvc;

namespace ShopProjectAPPAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> TestAsync()
        {
            return Ok("asd");
        }
    }
}

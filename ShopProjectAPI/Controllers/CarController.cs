using Microsoft.AspNetCore.Mvc;
using ShopProjectAPI.Attributes;

namespace ShopProjectAPI.Controllers
{
    [ApiController]
    [Bearer]
    [Route("[controller]/[action]")]
    public class CarController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("test");
        }
    }
}

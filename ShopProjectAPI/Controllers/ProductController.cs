using Microsoft.AspNetCore.Mvc;

namespace ShopProjectAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("asd");
        }
    }
}

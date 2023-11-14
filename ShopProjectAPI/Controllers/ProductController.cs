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
            var result = new List<string>();
            result.Add("asd");
            result.Add("asd111");
            return Ok(result);
        }
    }
}

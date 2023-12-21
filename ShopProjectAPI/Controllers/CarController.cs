using Microsoft.AspNetCore.Mvc;
using ShopProjectAPI.Attributes;
using ShopProjectAPI.DB;
using ShopProjectExternalModel.User;

namespace ShopProjectAPI.Controllers
{
    [ApiController]
    [Bearer]
    [Route("[controller]/[action]")]
    public class CarController : ControllerBase
    {
        ShopprojectContext db;

        public CarController(ShopprojectContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Test()
        {
            var result = db.Users.Select(x => new UserLoginModel
            {
                Username = x.Username,
                Password = x.Password
            }).ToArray();

            return Ok(result);
        }
    }
}

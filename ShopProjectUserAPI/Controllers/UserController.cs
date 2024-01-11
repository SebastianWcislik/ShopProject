using Microsoft.AspNetCore.Mvc;
using ShopProjectInfrastructure.Interfaces;
using ShopProjectInfrastructure.Attributes;
using ShopProjectExternalModel.User;

namespace ShopProjectUserAPI.Controllers
{
    [ApiController]
    [Bearer]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        IUserRepository user;

        public UserController(IUserRepository user)
        {
            this.user = user;
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserLoginModel userLogin)
        {
            var result = user.Login(userLogin);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetUserById([FromQuery] int UserId)
        {
            var result = user.GetUserById(UserId);
            return Ok(result);
        }
    }
}

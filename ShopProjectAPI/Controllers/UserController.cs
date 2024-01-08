using Microsoft.AspNetCore.Mvc;
using ShopProjectAPI.Attributes;
using ShopProjectAPI.Interfaces;
using ShopProjectExternalModel.User;

namespace ShopProjectAPI.Controllers
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
        public IActionResult Login([FromBody]UserLoginModel userLogin)
        {
            var result = user.Login(userLogin);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Register([FromBody]UserRegisterModel userRegister)
        {
            var result = user.Register(userRegister);
            return Ok(result);
        }
    }
}

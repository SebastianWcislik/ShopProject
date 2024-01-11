using Microsoft.AspNetCore.Mvc;
using ShopProjectExternalModel.User;
using ShopProjectInfrastructure.Attributes;
using ShopProjectInfrastructure.Interfaces;

namespace ShopProjectUserActionsAPI.Controllers
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
        public IActionResult Register([FromBody] UserRegisterModel userRegister)
        {
            var result = user.Register(userRegister);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult ChangePassword([FromBody] UserUpdateModel userUpdate)
        {
            var result = user.ChangePassword(userUpdate.UserId, userUpdate.Password);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteUser([FromQuery] int UserId)
        {
            var result = user.DeleteUser(UserId);
            return Ok(result);
        }
    }
}

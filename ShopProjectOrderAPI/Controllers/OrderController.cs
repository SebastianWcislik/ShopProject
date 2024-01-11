using Microsoft.AspNetCore.Mvc;
using ShopProjectInfrastructure.Attributes;
using ShopProjectInfrastructure.Interfaces;

namespace ShopProjectOrderAPI.Controllers
{
    [ApiController]
    [Bearer]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private IOrderRepository or;

        public OrderController(IOrderRepository or)
        {
            this.or = or;
        }

        [HttpGet]
        public IActionResult GetOrderGames([FromQuery] int OrderId)
        {
            var result = or.GetOrderGamesById(OrderId);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetUserOrders([FromQuery] int UserId)
        {
            var result = or.GetUserOrders(UserId);
            return Ok(result);
        }
    }
}

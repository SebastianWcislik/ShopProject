using Microsoft.AspNetCore.Mvc;
using ShopProjectAPI.Attributes;
using ShopProjectAPI.Interfaces;
using ShopProjectExternalModel.Cart;
using ShopProjectExternalModel.Order;

namespace ShopProjectAPI.Controllers
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

        [HttpPost]
        public IActionResult AddOrder([FromBody]List<CartModel> order)
        {
            var result = or.AddOrders(order);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetOrderGames([FromQuery]int OrderId)
        {
            var result = or.GetOrderGamesById(OrderId);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetUserOrders([FromQuery]int UserId) 
        {
            var result = or.GetUserOrders(UserId);
            return Ok(result);
        }
    }
}

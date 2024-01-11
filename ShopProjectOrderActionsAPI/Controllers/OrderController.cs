using Microsoft.AspNetCore.Mvc;
using ShopProjectExternalModel.Cart;
using ShopProjectInfrastructure.Attributes;
using ShopProjectInfrastructure.Interfaces;

namespace ShopProjectOrderActionsAPI.Controllers
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
        public IActionResult AddOrder([FromBody] List<CartModel> order)
        {
            var result = or.AddOrders(order);
            return Ok(result);
        }
    }
}

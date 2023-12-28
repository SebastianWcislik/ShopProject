using Microsoft.AspNetCore.Mvc;
using ShopProjectAPI.Attributes;
using ShopProjectAPI.Interfaces;

namespace ShopProjectAPI.Controllers
{
    [ApiController]
    [Bearer]
    [Route("[controller]/[action]")]
    public class ProductsController : ControllerBase
    {
        public IProductsRepository productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var result = productsRepository.GetProducts();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetProduct([FromQuery]int id)
        {
            var result = productsRepository.GetProduct(id);
            return Ok(result);
        }
    }
}

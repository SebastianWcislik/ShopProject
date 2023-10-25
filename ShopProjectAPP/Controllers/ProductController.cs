using Microsoft.AspNetCore.Mvc;
using ShopProjectAPP.Interfaces;
using ShopProjectAPP.Models;
using ShopProjectAPP.ViewModels;

namespace ShopProjectAPP.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = _productRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _productRepository.GetAll();
            return View(products);
        }

        public async Task<ActionResult> Detail(int id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel productVM)
        {
            if (ModelState.IsValid)
            {

                var product = new Product
                {
                    Title = productVM.Title,
                    Description = productVM.Description,
                    ProductCategory = productVM.ProductCategory,
                };
                _productRepository.Add(product);
                return RedirectToAction("Index");
            }
            return View(productVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return View("Error");
            var productVM = new EditProductViewModel
            {
                Title = product.Title,
                Description = product.Description,
                ProductCategory = product.ProductCategory,
            };
            return View(productVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditProductViewModel productVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit product");
                return View("Edit", productVM);
            }

            var user = await _productRepository.GetByIdAsyncNoTracking(id);

            if (user != null)
            {

                var product = new Product
                {
                    Id = id,
                    Title = productVM.Title,
                    Description = productVM.Description,
                };

                _productRepository.Update(product);

                return RedirectToAction("Index");
            }
            else
            {
                return View(productVM);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var productDetails = await _productRepository.GetByIdAsync(id);
            if (productDetails == null) return View("Error");
            return View(productDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var productDetails = await _productRepository.GetByIdAsync(id);
            if (productDetails == null) return View("Error");

            _productRepository.Delete(productDetails);
            return RedirectToAction("Index");
        }
    }
}

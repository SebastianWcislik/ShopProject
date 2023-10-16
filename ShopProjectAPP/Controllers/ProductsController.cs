using Microsoft.AspNetCore.Mvc;
using ShopProjectAPP.Models;

namespace ShopProjectAPP.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel productsVM)
        {
            if (ModelState.IsValid)
            {
                var club = new Product
                {
                    Title = productsVM.Title,
                    Description = productsVM.Description,
                };
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(productsVM);
        }
    }
}

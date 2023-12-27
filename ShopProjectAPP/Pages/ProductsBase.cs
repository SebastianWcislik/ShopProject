using Microsoft.AspNetCore.Components;
using ShopProjectAPP.Services.Interfaces;
using ShopProjectExternalModel.Product;

namespace ShopProjectAPP.Pages
{
    public class ProductsBase: ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }

        public IEnumerable<ProductDto> Products { get; set;}

        protected override async Task OnInitializedAsync()
        {
            Products = await ProductService.GetItems();
        }
    }
}

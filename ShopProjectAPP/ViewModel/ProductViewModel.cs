using Microsoft.AspNetCore.Components;
using ShopProjectAPP.Helpers;
using ShopProjectExternalModel.Product;

namespace ShopProjectAPP.ViewModel
{
    public class ProductViewModel : ComponentBase
    {
        public HttpHelpers httpHelper;

        public ProductViewModel()
        {
            this.httpHelper = new HttpHelpers();
        }

        public ProductDto[] Products { get; set; }

        public async Task<ProductDto[]> GetProducts()
        {
            var result = await httpHelper.GetResponse<ProductDto[]>(Program.url + "/Products/GetProducts");
            return result;
        }

        protected override async void OnInitialized()
        {
            var result = await GetProducts();
            Products = result;
            StateHasChanged();
        }
    }
}

using Microsoft.AspNetCore.Components;
using ShopProjectAPP.Helpers;
using ShopProjectExternalModel.Product;

namespace ShopProjectAPP.ViewModel
{
    public class ProductDetailViewModel : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        public ProductDto Product { get; set; }
        public HttpHelpers httpHelper { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ProductDetailViewModel() 
        {
            this.httpHelper = new HttpHelpers();
        }

        public async Task<ProductDto> GetProduct()
        {
            var result = await httpHelper.GetResponse<ProductDto>(Program.url + "/Products/GetProduct?Id=" + Id);
            return result;
        }

        protected override async void OnInitialized()
        {
            var result = await GetProduct();
            if (result != null)
            {
                Product = result;
                StateHasChanged();
            }
            else
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}

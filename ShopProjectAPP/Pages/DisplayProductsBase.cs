using Microsoft.AspNetCore.Components;
using ShopProjectExternalModel.Product;

namespace ShopProjectAPP.Pages
{
    public class DisplayProductsBase:ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDto> Products { get; set;}
    }
}

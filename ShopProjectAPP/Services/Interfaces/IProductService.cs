using ShopProjectExternalModel.Product;

namespace ShopProjectAPP.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetItems();
    }
}

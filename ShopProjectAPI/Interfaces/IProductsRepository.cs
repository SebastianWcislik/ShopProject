using ShopProjectExternalModel.Product;

namespace ShopProjectAPI.Interfaces
{
    public interface IProductsRepository
    {
        ProductDto GetProduct(int id);
        ProductDto[] GetProducts();
    }
}
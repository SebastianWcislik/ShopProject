using ShopProjectAPP.Models;

namespace ShopProjectAPP.Interfaces
{
    public interface IProductsRepository
    {
            bool Add(Product product);

            bool Update(Product product);

            bool Delete(Product product);

            bool Save();
    }
}

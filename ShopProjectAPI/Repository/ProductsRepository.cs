using ShopProjectAPI.DB;
using ShopProjectAPI.Interfaces;
using ShopProjectExternalModel.Product;

#nullable disable

namespace ShopProjectAPI.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        public ShopprojectContext db { get; set; }

        public ProductsRepository(ShopprojectContext db)
        {
            this.db = db;
        }

        public ProductDto[] GetProducts()
        {
            var result = db.Products.Join(db.ProductCategories, c => c.CategoryId, d => d.Id, (p, pc) => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ImageURL = p.ImageUrl,
                Price = p.Price,
                CategoryId = pc.Id,
                CategoryName = pc.Name
            }).ToArray();

            return result;
        }

        public ProductDto GetProduct(int id)
        {
            var result = db.Products.Join(db.ProductCategories, c => c.CategoryId, d => d.Id, (p, pc) => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ImageURL = p.ImageUrl,
                Price = p.Price,
                CategoryId = pc.Id,
                CategoryName = pc.Name
            }).FirstOrDefault(x => x.Id == id);

            if (result != null) return result;
            else return null;
        }
    }
}

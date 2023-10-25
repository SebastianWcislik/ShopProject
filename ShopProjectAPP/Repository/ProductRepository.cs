using Microsoft.EntityFrameworkCore;
using ShopProjectAPP.Data;
using ShopProjectAPP.Interfaces;
using ShopProjectAPP.Models;

namespace ShopProjectAPP.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Product> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Products.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Add(Product product)
        {
            _context.Add(product);
            return Save();
        }

        public bool Update(Product product)
        {
            _context.Update(product);
            return Save();
        }

        public bool Delete(Product product)
        {
            _context.Remove(product);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}

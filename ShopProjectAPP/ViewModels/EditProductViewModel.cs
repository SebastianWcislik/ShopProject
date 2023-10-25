using ShopProjectAPP.Data.Enum;
using ShopProjectAPP.Models;

namespace ShopProjectAPP.ViewModels
{
    public class EditProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public IFormFile Image { get; set; }
        public string? URL { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}

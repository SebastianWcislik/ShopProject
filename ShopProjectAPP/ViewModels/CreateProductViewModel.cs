using ShopProjectAPP.Data.Enum;

namespace ShopProjectAPP.ViewModels
{
    public class CreateProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}

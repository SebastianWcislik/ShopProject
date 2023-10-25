using ShopProjectAPP.Data.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace ShopProjectAPP.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
        public ProductCategory ProductCategory { get; set; }
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public object Address { get; internal set; }
    }
}

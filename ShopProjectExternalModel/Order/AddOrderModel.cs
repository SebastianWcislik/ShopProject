using System.ComponentModel.DataAnnotations;

namespace ShopProjectExternalModel.Order
{
    public class AddOrderModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int GameId { get; set; }
    }
}

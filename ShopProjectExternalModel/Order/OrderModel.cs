using System.ComponentModel.DataAnnotations;

namespace ShopProjectExternalModel.Order
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int UserId {  get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

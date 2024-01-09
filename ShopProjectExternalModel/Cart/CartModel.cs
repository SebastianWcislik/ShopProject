namespace ShopProjectExternalModel.Cart
{
    public class CartModel
    {
        public int UserId {  get; set; }
        public int GameId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? ImageURL { get; set; }
        public int? Quantity { get; set; }
    }
}

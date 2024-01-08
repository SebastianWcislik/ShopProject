using ShopProjectExternalModel.Game;

namespace ShopProjectExternalModel.Order
{
    public class OrderGamesModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int GameId { get; set; }
        public string Key { get; set; } = null!;
        public virtual GameModel Game { get; set; } = null!;
        public virtual OrderModel Order { get; set; } = null!;
    }
}

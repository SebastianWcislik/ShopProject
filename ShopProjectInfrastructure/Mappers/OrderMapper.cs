using ShopProjectInfrastructure.DB;
using ShopProjectExternalModel.Order;

namespace ShopProjectInfrastructure.Mappers
{
    public class OrderMapper
    {
        private GameMapper gm;

        public OrderMapper(GameMapper gm)
        {
            this.gm = gm;
        }

        public OrderGamesModel MapToOrderWithGames(OrderGame x)
        {
            return new OrderGamesModel
            {
                Id = x.Id,
                Key = x.Key,
                GameId = x.GameId,
                OrderId = x.OrderId,
                Game = gm.MapToGameModel(x.Game),
                Order = MapToOrderModel(x.Order)
            };
        }

        public OrderModel MapToOrderModel(Order x)
        {
            return new OrderModel 
            { 
                Id = x.Id, 
                UserId = x.UserId, 
                CreatedDate = x.CreatedDate
            };
        }
    }
}

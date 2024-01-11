using ShopProjectInfrastructure.DB;
using ShopProjectInfrastructure.Interfaces;
using ShopProjectInfrastructure.Mappers;
using ShopProjectExternalModel.Cart;
using ShopProjectExternalModel.Order;
using ShopProjectExternalModel.Responses;

namespace ShopProjectInfrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private ShopprojectContext db;
        private IGamesRepository gr;
        private IUserRepository ur;
        private OrderMapper om;

        public OrderRepository(ShopprojectContext db, IGamesRepository gr, IUserRepository ur, OrderMapper om)
        {
            this.db = db;
            this.gr = gr;
            this.ur = ur;
            this.om = om;
        }

        public AddOrdersMessage AddOrders(List<CartModel> orders)
        {
            foreach (var order in orders)
            {
                if (!ur.CheckUserById(order.UserId)) return new AddOrdersMessage { OrderId = 0 };
                if (!gr.CheckGameById(order.GameId)) return new AddOrdersMessage { OrderId = 0 };
            }

            var createdOrder = new Order
            {
                UserId = orders[0].UserId,
                CreatedDate = DateTime.Now,
            };
            db.Orders.Add(createdOrder);
            db.SaveChanges();

            foreach (var order in orders)
            {
                db.OrderGames.Add(new OrderGame
                {
                    OrderId = createdOrder.Id,
                    GameId = order.GameId,
                    Key = Guid.NewGuid().ToString(),
                });
            }
            db.SaveChanges();

            return new AddOrdersMessage { OrderId = createdOrder.Id };
        }

        public OrderGamesModel[] GetOrderGamesById(int OrderId)
        {
            var orderGames = db.OrderGames.Where(x => x.OrderId == OrderId);

            if (orderGames.Count() != 0)
            {
                var order = db.Orders.First(x => x.Id == orderGames.First().OrderId);
                foreach (var orderGame in orderGames)
                {
                    orderGame.Game = db.Games.First(x => x.Id == orderGame.GameId);
                    orderGame.Order = order;
                }
                var result = orderGames.Select(x => om.MapToOrderWithGames(x)).ToArray();
                return result;
            }
            else
            {
                return new OrderGamesModel[] { };
            }
        }

        public UserOrdersMessage[] GetUserOrders(int UserId)
        {
            var result = db.Orders.Where(x => x.UserId == UserId).Select(x => new UserOrdersMessage
            {
                Id = x.Id,
                CreatedDate = x.CreatedDate
            }).ToArray();
            if (result.Length != 0) return result;
            else return null;
        }
    }
}

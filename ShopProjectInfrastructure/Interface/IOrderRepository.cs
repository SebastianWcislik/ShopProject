using ShopProjectExternalModel.Cart;
using ShopProjectExternalModel.Order;
using ShopProjectExternalModel.Responses;

namespace ShopProjectInfrastructure.Interfaces
{
    public interface IOrderRepository
    {
        AddOrdersMessage AddOrders(List<CartModel> orders);
        OrderGamesModel[] GetOrderGamesById(int OrderId);
        UserOrdersMessage[] GetUserOrders(int UserId);
    }
}
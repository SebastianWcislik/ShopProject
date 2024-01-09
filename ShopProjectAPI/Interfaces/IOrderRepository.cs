using ShopProjectExternalModel.Order;
using ShopProjectExternalModel.Responses;

namespace ShopProjectAPI.Interfaces
{
    public interface IOrderRepository
    {
        AddOrdersMessage AddOrders(List<AddOrderModel> orders);
        OrderGamesModel[] GetOrderGamesById(int OrderId);
        UserOrdersMessage[] GetUserOrders(int UserId);
    }
}
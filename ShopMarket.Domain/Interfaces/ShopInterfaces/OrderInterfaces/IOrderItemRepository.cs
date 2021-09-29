using System.Linq;
using ShopMarket.Domain.ShopEntities.OrderEntities;

namespace ShopMarket.Domain.Interfaces.ShopInterfaces.OrderInterfaces
{
    public interface IOrderItemRepository
    {
        IQueryable<OrderItem> GetItemsOfOrder(int orderId);

        void InsertOrderItem(OrderItem orderItem);

        void UpdateOrderItem(OrderItem orderItem);

        void DeleteOrderItem(OrderItem orderItem);

        void DeleteOrderItem(int id);

        void Save();
        bool OrderHasItem(int productId, int orderId);
        OrderItem GetItemOfOrderByProductId(int productId, int orderId);
        OrderItem GetOrderItem(int id);
    }
}
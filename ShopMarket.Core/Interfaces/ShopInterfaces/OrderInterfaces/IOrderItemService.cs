using System.Collections.Generic;
using System.Linq;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.ShopEntities.OrderEntities;

namespace ShopMarket.Domain.Interfaces.ShopInterfaces.OrderInterfaces
{
    public interface IOrderItemService
    {
        IQueryable<OrderItem> GetItemsOfOrder(int orderId);

        OperationResult InsertOrderItem(OrderItem orderItem);

        OperationResult UpdateOrderItem(OrderItem orderItem);

        OperationResult DeleteOrderItem(OrderItem orderItem);

        OperationResult DeleteOrderItem(int id);

        bool HasItem(int productId, int orderId);
        OrderItem GetItemOfOrderByProductId(int productId, int orderId);
        OrderItem GetOrderItem(int id);

    }
}
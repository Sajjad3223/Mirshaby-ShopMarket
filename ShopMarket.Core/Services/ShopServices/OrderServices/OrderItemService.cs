using ShopMarket.Core.Utilities;
using ShopMarket.Domain.Interfaces.ShopInterfaces.OrderInterfaces;
using ShopMarket.Domain.ShopEntities.OrderEntities;
using System.Linq;

namespace ShopMarket.Core.Services.ShopServices.OrderServices
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public OperationResult DeleteOrderItem(OrderItem orderItem)
        {
            try
            {
                if (orderItem == null)
                    return OperationResult.NotFound();
                _orderItemRepository.DeleteOrderItem(orderItem);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult DeleteOrderItem(int id)
        {
            try
            {
                if (id == null)
                    return OperationResult.NotFound();
                _orderItemRepository.DeleteOrderItem(id);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OrderItem GetOrderItem(int id)
        {
            return _orderItemRepository.GetOrderItem(id);
        }

        public IQueryable<OrderItem> GetItemsOfOrder(int orderId)
        {
            if (orderId == null)
            {
                return null;
            }
            var items = _orderItemRepository.GetItemsOfOrder(orderId);
            var availableItems = items.Where(i => (i.Product.Remaining > 0 && i.Count <= i.Product.Remaining) || i.Price != null);
            return availableItems;
        }

        public bool HasItem(int productId, int orderId)
        {
            return _orderItemRepository.OrderHasItem(productId, orderId);
        }

        public OrderItem GetItemOfOrderByProductId(int productId, int orderId)
        {
            return _orderItemRepository.GetItemOfOrderByProductId(productId, orderId);
        }

        public OperationResult InsertOrderItem(OrderItem orderItem)
        {
            try
            {
                if (orderItem == null)
                    return OperationResult.NotFound();
                _orderItemRepository.InsertOrderItem(orderItem);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult UpdateOrderItem(OrderItem orderItem)
        {
            try
            {
                if (orderItem == null)
                    return OperationResult.NotFound();
                _orderItemRepository.UpdateOrderItem(orderItem);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }
    }
}
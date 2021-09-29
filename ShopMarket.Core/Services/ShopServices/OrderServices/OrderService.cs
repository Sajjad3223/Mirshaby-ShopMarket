using ShopMarket.Core.Utilities;
using ShopMarket.Domain.Interfaces.ShopInterfaces.OrderInterfaces;
using ShopMarket.Domain.ShopEntities.OrderEntities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Core.Utilities.Mappers;
using ShopMarket.Core.ViewModels.ShopViewModels.OrderViewModels;

namespace ShopMarket.Core.Services.ShopServices.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OperationResult DeleteOrder(OrderViewModel order)
        {
            try
            {
                if (order == null)
                    return OperationResult.NotFound();
                _orderRepository.DeleteOrder(order.MapToOrder());
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult DeleteOrder(int id)
        {
            try
            {
                if (id == null)
                    return OperationResult.NotFound();
                _orderRepository.DeleteOrder(id);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public void FinializeOrder(OrderViewModel order,long refId)
        {
            order.OrderStatus = EOrderStatus.Paid;
            order.RefId = refId;
            UpdateOrder(order);
        }

        public IQueryable<OrderViewModel> GetAll()
        {
            return _orderRepository.GetAll().Select(o=>o.MapToViewModel());
        }

        public async Task<OrderViewModel> GetOrder(int id)
        {
            var order = await _orderRepository.GetOrder(id);
            if(order != null)
                return order.MapToViewModel();
            return null;
        }

        public async Task<OrderViewModel> GetUserOpenOrder(int userId)
        {
            return (await _orderRepository.GetUserOpenOrder(userId)).MapToViewModel();
        }

        public IQueryable<OrderViewModel> GetUserOrders(int userId)
        {
            var userOrders =  _orderRepository.GetUserOrders(userId);
            return userOrders.Where(o=>o != null).OrderByDescending(o=>o.CreationDate).Select(o => o.MapToViewModel());
        }

        public Task<bool> HasOpenOrder(int userId)
        {
            return _orderRepository.HasOpenOrder(userId);
        }

        public OrderViewModel InsertOrder(OrderViewModel order)
        {
            var addOrder = _orderRepository.InsertOrder(order.MapToOrder());
            return addOrder.MapToViewModel();
        }
        

        public OperationResult UpdateOrder(OrderViewModel order)
        {
            try
            {
                if (order == null)
                    return OperationResult.NotFound();
                _orderRepository.UpdateOrder(order.MapToOrder());
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }
    }
}
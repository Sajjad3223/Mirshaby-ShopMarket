using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.ViewModels.ShopViewModels.OrderViewModels;
using ShopMarket.Domain.ShopEntities.OrderEntities;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Domain.Interfaces.ShopInterfaces.OrderInterfaces
{
    public interface IOrderService
    {
        IQueryable<OrderViewModel> GetAll();
        IQueryable<OrderViewModel> GetUserOrders(int userId);

        Task<OrderViewModel> GetOrder(int id);

        Task<OrderViewModel> GetUserOpenOrder(int userId);

        Task<bool> HasOpenOrder(int userId);

        OrderViewModel InsertOrder(OrderViewModel order);

        OperationResult UpdateOrder(OrderViewModel order);

        OperationResult DeleteOrder(OrderViewModel order);

        OperationResult DeleteOrder(int id);

        void FinializeOrder(OrderViewModel order,long refId);
    }
}
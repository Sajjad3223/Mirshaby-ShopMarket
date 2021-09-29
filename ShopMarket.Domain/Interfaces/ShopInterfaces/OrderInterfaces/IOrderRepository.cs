using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Domain.ShopEntities.OrderEntities;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Domain.Interfaces.ShopInterfaces.OrderInterfaces
{
    public interface IOrderRepository
    {
        IQueryable<Order> GetAll();
        IQueryable<Order> GetUserOrders(int userId);

        Task<Order> GetOrder(int id);

        Task<Order> GetUserOpenOrder(int userId);

        Task<bool> HasOpenOrder(int userId);

        Order InsertOrder(Order order);
                   
        void UpdateOrder(Order order);
                   
        void DeleteOrder(Order order);
                   
        void DeleteOrder(int id);

        void Save();
    }
}
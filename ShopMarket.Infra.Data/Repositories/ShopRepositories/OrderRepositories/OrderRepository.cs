using ShopMarket.Domain.Interfaces.ShopInterfaces.OrderInterfaces;
using ShopMarket.Domain.ShopEntities.OrderEntities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Infra.Data.Repositories.ShopRepositories.OrderRepositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopMarketDbContext _context;

        public OrderRepository(ShopMarketDbContext context)
        {
            _context = context;
        }

        public void DeleteOrder(Order order)
        {
            order.IsDeleted = true;
            UpdateOrder(order);
        }

        public async void DeleteOrder(int id)
        {
            var order = await GetOrder(id);
            DeleteOrder(order);
        }

        public IQueryable<Order> GetAll()
        {
            return _context.Orders;
        }

        public Task<Order> GetOrder(int id)
        {
            return _context.Orders.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);
        }

        public Task<Order> GetUserOpenOrder(int userId)
        {
            return _context.Orders.AsNoTracking()
                .FirstOrDefaultAsync(o => o.UserId == userId && o.OrderStatus == EOrderStatus.NotPaid);
        }

        public IQueryable<Order> GetUserOrders(int userId)
        {
            return _context.Orders.Where(o => o.UserId == userId);
        }

        public Task<bool> HasOpenOrder(int userId)
        {
            return _context.Orders.AnyAsync(o => o.UserId == userId && o.OrderStatus == EOrderStatus.NotPaid);
        }

        public Order InsertOrder(Order order)
        {
            _context.Add(order);
            Save();
            return order;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _context.Update(order);
            Save();
        }
    }
}

    
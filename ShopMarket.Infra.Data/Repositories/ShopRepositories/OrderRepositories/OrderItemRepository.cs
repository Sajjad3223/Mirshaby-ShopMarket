using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Domain.Interfaces.ShopInterfaces.OrderInterfaces;
using ShopMarket.Domain.ShopEntities.OrderEntities;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Infra.Data.Repositories.ShopRepositories.OrderRepositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ShopMarketDbContext _context;

        public OrderItemRepository(ShopMarketDbContext context)
        {
            _context = context;
        }

        public void DeleteOrderItem(OrderItem orderItem)
        {
            _context.Remove(orderItem);
            Save();
        }

        public void DeleteOrderItem(int id)
        {
            var orderItem = GetOrderItem(id);
            DeleteOrderItem(orderItem);
        }

        public IQueryable<OrderItem> GetItemsOfOrder(int orderId)
        {
            return _context.OrderItems.AsNoTracking().Where(o => o.OrderId == orderId).Include(p=>p.Product);
        }

        public void InsertOrderItem(OrderItem orderItem)
        {
            _context.Add(orderItem);
            Save();
        }

        public bool OrderHasItem(int productId, int orderId)
        {
            return _context.OrderItems.Any(oi => oi.ProductId == productId && oi.OrderId == orderId);
        }

        public OrderItem GetItemOfOrderByProductId(int productId, int orderId)
        {
            return _context.OrderItems.AsNoTracking().FirstOrDefault(o => o.ProductId == productId && o.OrderId == orderId);
        }

        public OrderItem GetOrderItem(int id)
        {
            return _context.OrderItems.AsNoTracking().FirstOrDefault(o => o.OrderItemId == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            _context.Update(orderItem);
            Save();
        }
    }
}
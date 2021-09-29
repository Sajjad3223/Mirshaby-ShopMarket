using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Domain.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Domain.ShopEntities.ProductEntities;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Infra.Data.Repositories.ShopRepositories.ProductRepositories
{
    public class AvailableProductColorRepository : IAvailableProductColorRepository 
    {
        private readonly ShopMarketDbContext _context;

        public AvailableProductColorRepository(ShopMarketDbContext context)
        {
            _context = context;
        }

        public void DeleteColor(AvailableProductColor color)
        {
            _context.Remove(color);
        }

        public async void DeleteColor(int id)
        {
            var color = await _context.AvailableProductColors.AsNoTracking().FirstOrDefaultAsync(c => c.AvaiableColorId == id);
            DeleteColor(color);
        }

        public IQueryable<AvailableProductColor> GetAllAvailableColors(int productId)
        {
            return _context.AvailableProductColors.Where(c => c.ProductId == productId);
        }

        public void InsertColor(AvailableProductColor color)
        {
            _context.Add(color);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateColor(AvailableProductColor color)
        {
            _context.Update(color);
        }
    }
}
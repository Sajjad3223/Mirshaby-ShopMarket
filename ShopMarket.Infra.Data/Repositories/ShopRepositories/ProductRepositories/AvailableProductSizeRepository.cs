using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Domain.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Domain.ShopEntities.ProductEntities;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Infra.Data.Repositories.ShopRepositories.ProductRepositories
{
    public class AvailableProductSizeRepository : IAvailableProductSizeRepository
    {
        private readonly ShopMarketDbContext _context;

        public AvailableProductSizeRepository(ShopMarketDbContext context)
        {
            _context = context;
        }

        public void DeleteSize(AvailableProductSize size)
        {
            _context.Remove(size);
        }

        public async void DeleteSize(int id)
        {
            var size = await _context.AvailableProductSizes.AsNoTracking().FirstOrDefaultAsync(c => c.AvaiableSizeId == id);
            DeleteSize(size);
        }

        public IQueryable<AvailableProductSize> GetAllAvailableSizes(int productId)
        {
            return _context.AvailableProductSizes.Where(c => c.ProductId == productId);
        }

        public void InsertSize(AvailableProductSize size)
        {
            _context.Add(size);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateSize(AvailableProductSize size)
        {
            _context.Update(size);
        }
    }
}
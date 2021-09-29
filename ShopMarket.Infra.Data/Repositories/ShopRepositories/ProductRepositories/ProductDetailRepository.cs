using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Domain.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Domain.ShopEntities.ProductEntities;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Infra.Data.Repositories.ShopRepositories.ProductRepositories
{
    public class ProductDetailRepository : IProductDetailRepository
    {
        private readonly ShopMarketDbContext _context;

        public ProductDetailRepository(ShopMarketDbContext context)
        {
            _context = context;
        }

        public void DeleteDetail(ProductDetail detail)
        {
            _context.Remove(detail);
        }

        public async void DeleteDetail(int id)
        {
            var detail = await _context.ProductDetails.AsNoTracking().FirstOrDefaultAsync(d => d.ProductDetailId == id);
            DeleteDetail(detail);
        }

        public IQueryable<ProductDetail> GetProductDetails(int productId)
        {
            return _context.ProductDetails.Where(d => d.ProductId == productId);
        }

        public void InsertDetail(ProductDetail detail)
        {
            _context.Add(detail);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateDetail(ProductDetail detail)
        {
            _context.Update(detail);
        }
    }
}
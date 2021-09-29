using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Domain.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Domain.ShopEntities.ProductEntities;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Infra.Data.Repositories.ShopRepositories.ProductRepositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly ShopMarketDbContext _context;

        public ProductImageRepository(ShopMarketDbContext context)
        {
            _context = context;
        }

        public void DeleteImage(ProductImage image)
        {
            _context.Remove(image);
            Save();
        }

        public async void DeleteImage(string imageId)
        {
            var image = await GetImage(imageId);
            DeleteImage(image);
        }

        public IQueryable<ProductImage> GetAll(int productId)
        {
            return _context.ProductImages.Where(i=>i.ProductId == productId);
        }

        public Task<ProductImage> GetImage(string imageId)
        {
            return _context.ProductImages.AsNoTracking().FirstOrDefaultAsync(i => i.ImageName == imageId);
        }

        public Task<ProductImage> GetMainImage(int productId)
        {
            return _context.ProductImages.Where(i => i.ProductId == productId).FirstOrDefaultAsync(i => i.IsMainImage);
        }

        public void InsertImage(ProductImage image)
        {
            _context.Add(image);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateImage(ProductImage image)
        {
            _context.Update(image);
            Save();
        }
    }
}
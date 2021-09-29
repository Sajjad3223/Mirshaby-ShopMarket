using System;
using ShopMarket.Domain.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Domain.ShopEntities.ProductEntities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Infra.Data.Repositories.ShopRepositories.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopMarketDbContext _context;

        public ProductRepository(ShopMarketDbContext context)
        {
            _context = context;
        }

        public void DeleteProduct(Product product)
        {
            product.IsDeleted = true;
            UpdateProduct(product);
            Save();
        }

        public async void DeleteProduct(int id)
        {
            var product = await GetProduct(id);
            DeleteProduct(product);
        }

        public IQueryable<Product> GetAll()
        {
            return _context.Products.Include(p=>p.ShopCategory).ThenInclude(p=>p.ParentCategory).Include(p=>p.Store);
        }

        public Task<Product> GetProduct(int id)
        {
            return _context.Products.AsNoTracking().IgnoreQueryFilters().FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<Product> GetProductByShortLink(string shortLink)
        {
            return _context.Products.AsTracking().FirstOrDefaultAsync(p => p.ShortLink == shortLink);
        }

        public IQueryable<Product> GetProductsByCategory(int categoryId)
        {
            return _context.Products.Where(p => p.CategoryId == categoryId);
        }

        public IQueryable<Product> GetProductsByStore(int storeId)
        {
            return _context.Products.Where(p => p.StoreId == storeId);
        }

        public int InsertProduct(Product product)
        {
            _context.Add(product);
            Save();
            return product.Id;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IQueryable<Product> GetShowInSliderProducts()
        {
            return _context.Products.AsNoTracking().Where(p => p.ShowInSlider);
        }

        public IQueryable<Product> GetMostVisitedProducts()
        {
            return _context.Products.AsNoTracking().OrderByDescending(p => p.Visit).Take(10);
        }

        public bool DoesLinkExists(string link)
        {
            return _context.Products.Any(p => p.ShortLink == link);
        }

        public IQueryable<Product> GetSpecialProducts()
        {
            return _context.Products.AsNoTracking().Where(p => p.Discount != null && p.Discount != 0 && p.DiscountCount > 10);
        }

        public IQueryable<Product> GetDeletedProducts()
        {
            return _context.Products.AsTracking().IgnoreQueryFilters().Where(p => p.IsDeleted);
        }

        public void ReActivateProduct(Product product)
        {
            product.IsDeleted = false;
            UpdateProduct(product);
            Save();
        }

        public void UpdateProduct(Product product)
        {
            _context.Update(product);
        }
    }
}
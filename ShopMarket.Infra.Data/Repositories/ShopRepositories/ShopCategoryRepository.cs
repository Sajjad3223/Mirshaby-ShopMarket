using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Domain.Interfaces.ShopInterfaces;
using ShopMarket.Domain.ShopEntities;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Infra.Data.Repositories.ShopRepositories
{
    public class ShopCategoryRepository : IShopCategoryRepository
    {
        private readonly ShopMarketDbContext _context;

        public ShopCategoryRepository(ShopMarketDbContext context)
        {
            _context = context;
        }

        public void DeleteCategory(ShopCategory category)
        {
            category.IsDeleted = true;
            UpdateCategory(category);
        }
        
        public async void DeleteCategory(int id)
        {
            var category = await GetCategory(id);
            DeleteCategory(category);
        }
        

        public Task<bool> DoesSlugExist(string slug)
        {
            return _context.ShopCategories.AnyAsync(c => c.Slug == slug);
        }

        public IQueryable<ShopCategory> GetAll()
        {
            return _context.ShopCategories.AsNoTracking();
        }

        public IQueryable<ShopCategory> GetCategoriesByParent(int parentId)
        {
            return _context.ShopCategories.Where(c=>c.ParentId == parentId);
        }

        public Task<ShopCategory> GetCategory(int id)
        {
            return _context.ShopCategories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<ShopCategory> GetCategory(string slug)
        {
            return _context.ShopCategories.AsNoTracking().FirstOrDefaultAsync(c => c.Slug == slug);
        }

        public void InsertCategory(ShopCategory category)
        {
            _context.Add(category);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateCategory(ShopCategory category)
        {
            _context.Update(category);
            Save();
        }
    }
}
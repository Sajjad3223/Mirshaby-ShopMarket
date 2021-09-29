using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Domain.Interfaces.ShopInterfaces;
using ShopMarket.Domain.ShopEntities;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Infra.Data.Repositories.ShopRepositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly ShopMarketDbContext _context;

        public StoreRepository(ShopMarketDbContext context)
        {
            _context = context;
        }

        public void DeleteStore(Store store)
        {
            store.IsDeleted = true;
            UpdateStore(store);
        }

        public async void DeleteStore(int id)
        {
            var store = await GetStore(id);
            DeleteStore(store);
        }

        public IQueryable<Store> GetAll()
        {
            return _context.Stores;
        }

        public Task<Store> GetStore(int id)
        {
            return _context.Stores.AsNoTracking().IgnoreQueryFilters().FirstOrDefaultAsync(s => s.Id == id);
        }

        public IQueryable<Store> GetUserStores(int userId)
        {
            return _context.Stores.Where(s => s.UserId == userId);
        }

        public void InsertStore(Store store)
        {
            _context.Add(store);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IQueryable<Store> GetDeletedStores()
        {
            return _context.Stores.AsNoTracking().IgnoreQueryFilters().Where(s => s.IsDeleted);
        }

        public void ReActivateStore(Store store)
        {
            store.IsDeleted = false;
            UpdateStore(store);
        }

        public void UpdateStore(Store store)
        {
            _context.Update(store);
            Save();
        }
    }
}
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Domain.ShopEntities;
using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.Interfaces.ShopInterfaces;

namespace ShopMarket.Core.Services.ShopServices
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public void DeleteStore(Store store)
        {
            _storeRepository.DeleteStore(store);
        }

        public async void DeleteStore(int id)
        {
            var store = await GetStore(id);
            DeleteStore(store);
        }

        public async Task<OperationResult> ReActivateStore(int id)
        {
            var store = await GetStore(id);
            _storeRepository.ReActivateStore(store);
            return OperationResult.Success();
        }

        public IQueryable<Store> GetAll()
        {
            return _storeRepository.GetAll();
        }

        public IQueryable<Store> GetDeletedStores()
        {
            return _storeRepository.GetDeletedStores();
        }

        public Task<Store> GetStore(int id)
        {
            return _storeRepository.GetStore(id);
        }

        public IQueryable<Store> GetUserStores(int userId)
        {
            return _storeRepository.GetUserStores(userId);
        }

        public void InsertStore(Store store)
        {
            _storeRepository.InsertStore(store);
        }

        public void UpdateStore(Store store)
        {
            _storeRepository.UpdateStore(store);
        }
    }
}
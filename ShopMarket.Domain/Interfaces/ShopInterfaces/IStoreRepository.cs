using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Domain.Interfaces.ShopInterfaces
{
    public interface IStoreRepository
    {
        IQueryable<Store> GetAll();

        IQueryable<Store> GetUserStores(int userId);

        Task<Store> GetStore(int id);

        void InsertStore(Store store);
                   
        void UpdateStore(Store store);
                   
        void DeleteStore(Store store);
                   
        void DeleteStore(int id);

        void Save();
        IQueryable<Store> GetDeletedStores();
        void ReActivateStore(Store store);
    }
}
using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Core.Interfaces.ShopInterfaces
{
    public interface IStoreService
    {
        IQueryable<Store> GetAll();

        IQueryable<Store> GetDeletedStores();

        IQueryable<Store> GetUserStores(int userId);

        Task<Store> GetStore(int id);

        void InsertStore(Store store);
                   
        void UpdateStore(Store store);
                   
        void DeleteStore(Store store);
                   
        void DeleteStore(int id);
        Task<OperationResult> ReActivateStore(int id);
    }
}
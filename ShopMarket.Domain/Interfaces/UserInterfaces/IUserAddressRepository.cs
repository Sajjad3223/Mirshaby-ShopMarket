using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Domain.Interfaces.UserInterfaces
{
    public interface IUserAddressRepository
    {
        IQueryable<UserAddress> GetUserAddresses(int userId);

        Task<UserAddress> GetAddress(int id);
        Task<UserAddress> GetUserActiveAddress(int userId);

        void InsertAddress(UserAddress address);

        void UpdateAddress(UserAddress address);

        void DeleteAddress(UserAddress address);

        void DeleteAddress(int id);

        void Save();
    }
}
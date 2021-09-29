using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.DTOs.UserDTOs;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.ViewModels.UserViewModels;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Core.Interfaces.UserInterfaces
{
    public interface IUserAddressService
    {
        IQueryable<UserAddressViewModel> GetUserAddresses(int userId);

        Task<UserAddressViewModel> Get(int id);
        Task<UserAddressViewModel> GetUserActiveAddress(int userId);

        OperationResult Insert(UserAddressViewModel address);

        OperationResult Update(UserAddressViewModel address);

        OperationResult ChangeActiveAddress(int addressIdToActive,int userId);

        OperationResult Delete(UserAddressViewModel address);

        OperationResult Delete(int id);
    }
}
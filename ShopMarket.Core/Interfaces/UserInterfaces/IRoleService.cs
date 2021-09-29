using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.DTOs.UserDTOs;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.ViewModels.UserViewModels;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Core.Interfaces.UserInterfaces
{
    public interface IRoleService
    {
        IQueryable<Role> GetAll();

        IQueryable<Role> GetDeletedRoles();

        Task<Role> Get(int id);

        int Insert(Role role);

        OperationResult Update(Role role);

        OperationResult Delete(Role role);

        OperationResult Delete(int id);
    }
}
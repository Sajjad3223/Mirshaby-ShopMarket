using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.DTOs.UserDTOs;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.ViewModels.UserViewModels;
using ShopMarket.Domain.UserEntities;
using ShopMarket.Domain.UserEntities.Permissions;

namespace ShopMarket.Core.Interfaces.UserInterfaces
{
    public interface IPermissionService
    {
        IQueryable<Permission> GetAll();

        Task<Permission> GetPermission(int id);

        OperationResult InsertPermission(Permission permission);

        OperationResult UpdatePermission(Permission permission);

        OperationResult DeletePermission(Permission permission);

        Task<OperationResult> DeletePermission(int id);

        bool DoesUserHasPermission(int userId, int permissionId);
    }
}
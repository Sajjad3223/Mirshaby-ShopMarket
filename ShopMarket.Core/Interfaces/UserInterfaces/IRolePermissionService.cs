using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.DTOs.UserDTOs;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.ViewModels.UserViewModels;
using ShopMarket.Domain.UserEntities;
using ShopMarket.Domain.UserEntities.Permissions;

namespace ShopMarket.Core.Interfaces.UserInterfaces
{
    public interface IRolePermissionService
    {
        IQueryable<RolePermission> GetAll();

        IQueryable<int> GetPermissionsByRole(int roleId);
        IQueryable<Role> GetRolesByPermission(int permissionId);

        Task<RolePermission> Get(int id);

        OperationResult AttachPermissionsToRole(int roleId, List<int> permissions);

        OperationResult Insert(RolePermission rolePermission);

        OperationResult Update(RolePermission rolePermission);

        OperationResult UpdatePermissionsOfRole(int roleId, List<int> permissions);

        OperationResult Delete(RolePermission rolePermission);

        OperationResult Delete(int id);
    }
}
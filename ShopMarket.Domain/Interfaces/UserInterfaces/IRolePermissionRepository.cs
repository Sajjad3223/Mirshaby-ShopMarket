using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Domain.UserEntities;
using ShopMarket.Domain.UserEntities.Permissions;

namespace ShopMarket.Domain.Interfaces.UserInterfaces
{
    public interface IRolePermissionRepository
    {
        IQueryable<RolePermission> GetAll();

        IQueryable<Permission> GetPermissionsByRole(int roleId);
        IQueryable<Role> GetRolesByPermission(int permissionId);

        IQueryable<RolePermission> GetRolePermissionsByRole(int roleId);

        Task<RolePermission> GetRolePermission(int id);

        void InsertRolePermission(RolePermission rolePermission);

        void UpdateRolePermission(RolePermission rolePermission);

        void DeleteRolePermission(RolePermission rolePermission);

        void DeleteRolePermission(int id);

        void Save();
    }
}
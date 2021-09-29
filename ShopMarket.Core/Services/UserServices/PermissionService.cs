using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.Interfaces.UserInterfaces;
using ShopMarket.Domain.UserEntities.Permissions;

namespace ShopMarket.Core.Services.UserServices
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IUserRoleRepository _userRolesRepository;

        public PermissionService(IPermissionRepository permissionRepository, IRolePermissionRepository rolePermissionRepository, IUserRoleRepository userRolesRepository)
        {
            _permissionRepository = permissionRepository;
            _rolePermissionRepository = rolePermissionRepository;
            _userRolesRepository = userRolesRepository;
        }

        public OperationResult DeletePermission(Permission permission)
        {
            try
            {
                if (permission == null)
                    return OperationResult.NotFound();
                _permissionRepository.DeletePermission(permission);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public async Task<OperationResult> DeletePermission(int id)
        {
            try
            {
                if (id == null)
                    return OperationResult.NotFound();
                var permission = await GetPermission(id);
                _permissionRepository.DeletePermission(permission);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public bool DoesUserHasPermission(int userId, int permissionId)
        {
            var roles = _rolePermissionRepository.GetRolesByPermission(permissionId).Select(r=>r.RoleId).ToList();
            var userRoles = _userRolesRepository.GetRolesByUser(userId).Select(r => r.RoleId).ToList();

            if (!userRoles.Any())
                return false;

            return roles.Any(r => userRoles.Contains(r));
        }

        public IQueryable<Permission> GetAll()
        {
            return _permissionRepository.GetAll();
        }

        public Task<Permission> GetPermission(int id)
        {
            try
            {
                if (id == null)
                    return null;
                return _permissionRepository.GetPermission(id);
            }
            catch
            {
                return null;
            }
        }

        public OperationResult InsertPermission(Permission permission)
        {
            try
            {
                if (permission == null)
                    return OperationResult.NotFound();
                _permissionRepository.InsertPermission(permission);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult UpdatePermission(Permission permission)
        {
            try
            {
                if (permission == null)
                    return OperationResult.NotFound();
                _permissionRepository.UpdatePermission(permission);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.Interfaces.UserInterfaces;
using ShopMarket.Domain.UserEntities;
using ShopMarket.Domain.UserEntities.Permissions;

namespace ShopMarket.Core.Services.UserServices
{
    public class RolePermissionService : IRolePermissionService
    {
        private readonly IRolePermissionRepository _rolePermissionRepository;

        public RolePermissionService(IRolePermissionRepository rolePermissionRepository)
        {
            _rolePermissionRepository = rolePermissionRepository;
        }

        public OperationResult Delete(RolePermission rolePermission)
        {
            try
            {
                if (rolePermission == null)
                    return OperationResult.NotFound();
                _rolePermissionRepository.DeleteRolePermission(rolePermission);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult Delete(int id)
        {
            try
            {
                if (id == null)
                    return OperationResult.NotFound();
                _rolePermissionRepository.DeleteRolePermission(id);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public Task<RolePermission> Get(int id)
        {
            try
            {
                if (id == null)
                    return null;
                return _rolePermissionRepository.GetRolePermission(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<RolePermission> GetAll()
        {
            return _rolePermissionRepository.GetAll();
        }

        public IQueryable<int> GetPermissionsByRole(int roleId)
        {
            if (roleId == null)
                return null;
            return _rolePermissionRepository.GetPermissionsByRole(roleId).Select(p=>p.PermissionId);
        }

        public IQueryable<Role> GetRolesByPermission(int permissionId)
        {
            if (permissionId == null)
                return null;
            return _rolePermissionRepository.GetRolesByPermission(permissionId);
        }
        
        public OperationResult Insert(RolePermission rolePermission)
        {
            try
            {
                _rolePermissionRepository.InsertRolePermission(rolePermission);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult AttachPermissionsToRole(int roleId, List<int> permissions)
        {
            try
            {
                foreach (int permissionId in permissions)
                {
                    Insert(new RolePermission()
                    {
                        RoleId = roleId,
                        PermissionId = permissionId
                    });
                }
                _rolePermissionRepository.Save();
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult Update(RolePermission rolePermission)
        {
            try
            {
                if (rolePermission == null)
                    return OperationResult.NotFound();
                _rolePermissionRepository.UpdateRolePermission(rolePermission);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult UpdatePermissionsOfRole(int roleId, List<int> permissions)
        {
            try
            {
                _rolePermissionRepository.GetRolePermissionsByRole(roleId).ToList().ForEach(rp=>Delete(rp));

                AttachPermissionsToRole(roleId, permissions);

                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }
    }
}
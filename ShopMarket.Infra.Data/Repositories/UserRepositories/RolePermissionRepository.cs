using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Domain.Interfaces.UserInterfaces;
using ShopMarket.Domain.UserEntities;
using ShopMarket.Domain.UserEntities.Permissions;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Infra.Data.Repositories.UserRepositories
{
    public class RolePermissionRepository : IRolePermissionRepository
    {
        private readonly ShopMarketDbContext _context;

        public RolePermissionRepository(ShopMarketDbContext context)
        {
            _context = context;
        }

        public IQueryable<RolePermission> GetAll()
        {
            return _context.RolePermissions;
        }

        public IQueryable<Permission> GetPermissionsByRole(int roleId)
        {
            var rolePermissions = _context.RolePermissions.Where(rp => rp.RoleId == roleId).Include(rp=>rp.Permission);
            return rolePermissions.Select(rp => rp.Permission);
        }

        public IQueryable<Role> GetRolesByPermission(int permissionId)
        {
            var rolePermissions = _context.RolePermissions.Where(rp => rp.PermissionId == permissionId).Include(rp => rp.Role);
            return rolePermissions.Select(rp => rp.Role);
        }

        public Task<RolePermission> GetRolePermission(int id)
        {
            return _context.RolePermissions.AsNoTracking().FirstOrDefaultAsync(rp => rp.RolePermissionId == id);
        }

        public void InsertRolePermission(RolePermission rolePermission)
        {
            _context.Add(rolePermission);
        }

        public void UpdateRolePermission(RolePermission rolePermission)
        {
            _context.Update(rolePermission);
        }

        public void DeleteRolePermission(RolePermission rolePermission)
        {
            _context.Remove(rolePermission);
        }

        public async void DeleteRolePermission(int id)
        {
            DeleteRolePermission(await GetRolePermission(id));
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IQueryable<RolePermission> GetRolePermissionsByRole(int roleId)
        {
            return _context.RolePermissions.Where(rp => rp.RoleId == roleId);
        }
    }
}
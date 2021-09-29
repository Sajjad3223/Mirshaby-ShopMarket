using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Domain.Interfaces.UserInterfaces;
using ShopMarket.Domain.UserEntities.Permissions;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Infra.Data.Repositories.UserRepositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ShopMarketDbContext _context;

        public PermissionRepository(ShopMarketDbContext context)
        {
            _context = context;
        }

        public void DeletePermission(Permission permission)
        {
            _context.Remove(permission);
            Save();
        }

        public async void DeletePermission(int id)
        {
            DeletePermission(await GetPermission(id));
        }

        public IQueryable<Permission> GetAll()
        {
            return _context.Permissions;
        }

        public Task<Permission> GetPermission(int id)
        {
            return _context.Permissions.AsNoTracking().FirstOrDefaultAsync(p => p.PermissionId == id);
        }

        public void InsertPermission(Permission permission)
        {
            _context.Add(permission);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdatePermission(Permission permission)
        {
            _context.Update(permission);
            Save();
        }
    }
}
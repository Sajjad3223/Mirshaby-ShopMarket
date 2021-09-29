using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Domain.Interfaces.UserInterfaces;
using ShopMarket.Domain.UserEntities;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Infra.Data.Repositories.UserRepositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ShopMarketDbContext _context;

        public RoleRepository(ShopMarketDbContext context)
        {
            _context = context;
        }

        public IQueryable<Role> GetAll()
        {
            return _context.Roles;
        }

        public Task<Role> GetRole(int roleId)
        {
            return _context.Roles.AsNoTracking().FirstOrDefaultAsync(r => r.RoleId == roleId);
        }

        public int InsertRole(Role role)
        {
            _context.Roles.Add(role);
            Save();
            return role.RoleId;
        }

        public void UpdateRole(Role role)
        {
            _context.Update(role);
            Save();
        }

        public void DeleteRole(Role role)
        {
            role.IsDelete = true;
            UpdateRole(role);
        }

        public async void DeleteRole(int id)
        {
            DeleteRole(await GetRole(id));
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IQueryable<Role> GetDeletedRoles()
        {
            return _context.Roles.AsNoTracking().IgnoreQueryFilters().Where(r => r.IsDelete);
        }
    }
}
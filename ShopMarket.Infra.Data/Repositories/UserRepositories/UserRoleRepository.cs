using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Domain.Interfaces.UserInterfaces;
using ShopMarket.Domain.UserEntities;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Infra.Data.Repositories.UserRepositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ShopMarketDbContext _context;

        public UserRoleRepository(ShopMarketDbContext context)
        {
            _context = context;
        }

        public void DeleteUserRole(UserRole userRole)
        {
            _context.Remove(userRole);
        }

        public async void DeleteUserRole(int id)
        {
            var userRole = await GetUserRole(id);
            DeleteUserRole(userRole);
        }

        public IQueryable<UserRole> GetAll()
        {
            return _context.UserRoles;
        }

        public IQueryable<Role> GetRolesByUser(int userId)
        {
            var userRoles = _context.UserRoles.Where(u => u.UserId == userId).Include(u=>u.Role);
            return userRoles.Select(r => r.Role);
        }

        public IQueryable<User> GetUsersByRole(int roleId)
        {
            var userRoles = _context.UserRoles.Where(u => u.RoleId == roleId).Include(u => u.User);
            return userRoles.Select(r => r.User);
        }

        public void InsertUserRole(UserRole userRole)
        {
            _context.Add(userRole);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateUserRole(UserRole userRole)
        {
            _context.Update(userRole);
        }

        public Task<UserRole> GetUserRole(int userRoleId)
        {
            return _context.UserRoles.AsNoTracking().FirstOrDefaultAsync(u => u.UserRoleId == userRoleId);
        }

        public IQueryable<UserRole> GetUserRolesOfUser(int userId)
        {
            return _context.UserRoles.AsNoTracking().Where(ur => ur.UserId == userId);
        }
    }
}
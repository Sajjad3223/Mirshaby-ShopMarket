using ShopMarket.Domain.Interfaces.UserInterfaces;
using ShopMarket.Domain.UserEntities;
using ShopMarket.Infra.Data.ShopMarketContext;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShopMarket.Infra.Data.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ShopMarketDbContext _context;

        public UserRepository(ShopMarketDbContext context)
        {
            _context = context;
        }

        public void DeleteUser(User user)
        {
            user.IsDeleted = true;
            _context.Update(user);
            _context.SaveChanges();
        }

        public async void DeleteUser(int id)
        {
            var user = await GetUser(id);
            DeleteUser(user);
        }

        public IQueryable<User> GetDisabledUsers()
        {
            return _context.Users.AsNoTracking().IgnoreQueryFilters().Where(u => u.IsDeleted);
        }

        public void ReActivateUser(User user)
        {
            user.IsDeleted = false;
            UpdateUser(user);
        }

        public Task<bool> DoesEmailExist(string email)
        {
            return _context.Users.AnyAsync(u => u.Email == email);
        }

        public Task<bool> DoesPhoneNumberExist(string phone)
        {
            return _context.Users.AnyAsync(u => u.PhoneNumber == phone);
        }

        public Task<bool> DoesUserExist(string phone, string password)
        {
            return _context.Users.AnyAsync(u => u.PhoneNumber == phone && u.Password == password);
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users;
        }

        public Task<User> GetUser(int id)
        {
            return _context.Users.AsNoTracking().IgnoreQueryFilters().FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<User> GetUserByPhone(string phone)
        {
            return _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.PhoneNumber == phone);
        }

        public Task<User> GetUserByActiveCode(string code)
        {
            return _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.ActiveCode == code);
        }

        public Task<User> GetUserByEmail(string email)
        {
            return _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
        }

        public  void InsertUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}
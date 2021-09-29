using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Domain.Interfaces.UserInterfaces;
using ShopMarket.Domain.UserEntities;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Infra.Data.Repositories.UserRepositories
{
    public class UserAddressRepository : IUserAddressRepository
    {
        private readonly ShopMarketDbContext _context;

        public UserAddressRepository(ShopMarketDbContext context)
        {
            _context = context;
        }

        public void DeleteAddress(UserAddress userAddress)
        {
            _context.Remove(userAddress);
            Save();
        }

        public async void DeleteAddress(int id)
        {
            var userAddress = await GetAddress(id);
            DeleteAddress(userAddress);
        }

        public Task<UserAddress> GetAddress(int id)
        {
            return _context.Addresses.AsNoTracking().FirstOrDefaultAsync(a => a.AddressId == id);
        }

        public Task<UserAddress> GetUserActiveAddress(int userId)
        {
            return _context.Addresses.AsNoTracking().FirstOrDefaultAsync(a => a.UserId == userId && a.IsSelectedAddress);
        }

        public IQueryable<UserAddress> GetUserAddresses(int userId)
        {
            return _context.Addresses.AsNoTracking().Where(a => a.UserId == userId);
        }

        public void InsertAddress(UserAddress userAddress)
        {
            var address = _context.Add(userAddress);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateAddress(UserAddress userAddress)
        {
            _context.Update(userAddress);
            Save();
        }
    }
}
using ShopMarket.Domain.Interfaces.ShopInterfaces;
using ShopMarket.Domain.ShopEntities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Infra.Data.Repositories.ShopRepositories
{
    public class DiscountCodeRepository : IDiscountCodeRepository
    {
        private readonly ShopMarketDbContext _context;

        public DiscountCodeRepository(ShopMarketDbContext context)
        {
            _context = context;
        }

        public void DeleteCode(DiscountCode code)
        {
            _context.Remove(code);
            Save();
        }

        public async void DeleteCode(int id)
        {
            var code = await GetCode(id);
            DeleteCode(code);
        }

        public Task<bool> DoesCodeExist(string code)
        {
            return _context.DiscountCodes.AnyAsync(c => c.Code == code);
        }

        public IQueryable<DiscountCode> GetAll()
        {
            return _context.DiscountCodes;
        }

        public Task<DiscountCode> GetCode(int id)
        {
            return _context.DiscountCodes.AsNoTracking().FirstOrDefaultAsync(c => c.DiscountCodeId == id);
        }

        public Task<DiscountCode> GetCode(string code)
        {
            return _context.DiscountCodes.AsNoTracking().FirstOrDefaultAsync(c => c.Code == code);
        }

        public void InsertCode(DiscountCode code)
        {
            _context.Add(code);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateCode(DiscountCode code)
        {
            _context.Update(code);
            Save();
        }
    }
}
using System.Linq;
using ShopMarket.Domain.Interfaces.ShopInterfaces;
using ShopMarket.Domain.ShopEntities;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Infra.Data.Repositories.ShopRepositories
{
    public class MainPageDetailRepository : IMainPageDetailRepository
    {
        private readonly ShopMarketDbContext _context;

        public MainPageDetailRepository(ShopMarketDbContext context)
        {
            _context = context;
        }

        public void Update(MainPageDetail detail)
        {
            _context.Update(detail);
            Save();
        }

        public MainPageDetail GetDetails()
        {
            return _context.MainPageDetails.First();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
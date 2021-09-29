using ShopMarket.Domain.Interfaces.ShopInterfaces;
using ShopMarket.Domain.ShopEntities;
using ShopMarket.Infra.Data.ShopMarketContext;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ShopMarket.Infra.Data.Repositories.ShopRepositories
{
    public class BannerRepository : IBannerRepository
    {
        private readonly ShopMarketDbContext _context;

        public BannerRepository(ShopMarketDbContext context)
        {
            _context = context;
        }

        public void DeleteBanner(Banner banner)
        {
            _context.Remove(banner);
        }

        public IQueryable<Banner> GetAllBanners()
        {
            return _context.Banners.AsNoTracking();
        }

        public void InsertBanner(Banner banner)
        {
            _context.Add(banner);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
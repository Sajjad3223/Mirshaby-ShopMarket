using System.Linq;
using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Domain.Interfaces.ShopInterfaces
{
    public interface IBannerRepository
    {
        IQueryable<Banner> GetAllBanners();

        void InsertBanner(Banner banner);
        void DeleteBanner(Banner banner);

        void Save();
    }
}
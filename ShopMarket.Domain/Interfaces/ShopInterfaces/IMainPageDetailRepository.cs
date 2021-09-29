using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Domain.Interfaces.ShopInterfaces
{
    public interface IMainPageDetailRepository
    {
        void Update(MainPageDetail detail);

        MainPageDetail GetDetails();

        void Save();
    }
}
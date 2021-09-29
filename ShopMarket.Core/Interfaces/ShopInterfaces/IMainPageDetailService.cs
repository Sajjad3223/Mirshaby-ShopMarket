using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Core.Interfaces.ShopInterfaces
{
    public interface IMainPageDetailService
    {
        void Update(MainPageDetail detail);

        MainPageDetail GetDetails();
    }
}
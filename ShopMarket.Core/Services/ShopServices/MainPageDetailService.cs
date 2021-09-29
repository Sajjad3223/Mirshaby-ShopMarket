using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Domain.Interfaces.ShopInterfaces;
using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Core.Services.ShopServices
{
    public class MainPageDetailService : IMainPageDetailService
    {
        private readonly IMainPageDetailRepository _detailRepository;

        public MainPageDetailService(IMainPageDetailRepository detailRepository)
        {
            _detailRepository = detailRepository;
        }


        public void Update(MainPageDetail detail)
        {
            _detailRepository.Update(detail);
        }

        public MainPageDetail GetDetails()
        {
            return _detailRepository.GetDetails();
        }
    }
}
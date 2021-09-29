using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;

namespace ShopMarket.ViewComponents.IndexComponents
{
    public class TopCategoriesViewComponent : ViewComponent
    {
        private readonly IBannerService _bannerService;

        public TopCategoriesViewComponent(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int skip = 0)
        {
            var categories = _bannerService.GetAllBanners().ToList();
            ViewBag.Skip = skip;
            return View(categories);
        }
    }
}
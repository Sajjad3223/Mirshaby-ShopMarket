using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Utilities;

namespace ShopMarket.ViewComponents
{
    public class LikedItemsPreviewViewComponent : ViewComponent
    {
        private readonly ILikedProductService _likedProductService;

        public LikedItemsPreviewViewComponent(ILikedProductService likedProductService)
        {
            _likedProductService = likedProductService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int likedCount = _likedProductService.GetUserLikedProducts((User as ClaimsPrincipal).GetUserId()).Count();

            return View(likedCount);
        }
    }
}
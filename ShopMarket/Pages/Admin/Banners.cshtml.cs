using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Security;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Pages.Admin
{
    [PermissionChecker(8)]
    public class BannersModel : PageModel
    {
        private readonly IBannerService _bannerService;

        public BannersModel(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        public IList<Banner> Banners { get; set; }

        public void OnGet()
        {
            Banners = _bannerService.GetAllBanners().ToList();
        }

        public IActionResult OnPost(List<IFormFile> banner_images , List<string> banner_links)
        {
            var result =
                _bannerService.UpdateBanners(new Tuple<List<IFormFile>, List<string>>(banner_images, banner_links));
            if (result.Status != OperationResultStatus.Success)
                return Page();

            return RedirectToPage("Index");
        }
    }
}

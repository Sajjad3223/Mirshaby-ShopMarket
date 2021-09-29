using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Core.DTOs.ProductDto;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Security;
using ShopMarket.Domain.ShopEntities;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Pages.Admin.Categories
{
    [PermissionChecker(6)]
    public class IndexModel : PageModel
    {
        private readonly IShopCategoryService _shopCategoryService;

        public IndexModel(IShopCategoryService shopCategoryService)
        {
            _shopCategoryService = shopCategoryService;
        }

        public ShopCategoryDto ShopCategoryDto { get; set; }

        public void OnGet()
        {
            ShopCategoryDto = new ShopCategoryDto();
            ShopCategoryDto.ShopCategories = _shopCategoryService.GetAll();
            ViewData["page"] = "categories";
        }
    }
}

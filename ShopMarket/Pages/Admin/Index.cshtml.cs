using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Security;

namespace ShopMarket.Pages.Admin
{
    [PermissionChecker(3)]
    public class IndexModel : PageModel
    {
        private readonly IMainPageDetailService _detailService;
        private readonly IShopCategoryService _categoryService;

        public IndexModel(IMainPageDetailService detailService, IShopCategoryService categoryService)
        {
            _detailService = detailService;
            _categoryService = categoryService;
        }

        public void OnGet()
        {
            ViewData["Categories"] = new SelectList(_categoryService.GetAll(), "CategoryId", "Title",
                _detailService.GetDetails().CategoryIdToShow);
        }

        public IActionResult OnPost(int? categoryId)
        {
            if(categoryId != null)
                if (_detailService.GetDetails().CategoryIdToShow != categoryId)
                {
                    var detail = _detailService.GetDetails();
                    detail.CategoryIdToShow = categoryId.Value;
                    _detailService.Update(detail);
                }

            return RedirectToPage("Index");
        }
    }
}

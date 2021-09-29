using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Security;
using ShopMarket.Core.Services.FileManager;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;
using ShopMarket.Domain.ShopEntities;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Pages.Admin.Categories
{
    [PermissionChecker(6)]
    public class CreateModel : PageModel
    {
        private readonly IShopCategoryService _categoryService;
        private readonly IFileManager _fileManager;

        public CreateModel(IShopCategoryService categoryService, IFileManager fileManager)
        {
            _categoryService = categoryService;
            _fileManager = fileManager;
        }

        public IActionResult OnGet()
        {
            var categories = _categoryService.GetAll().ToList();
            ViewData["Categories"] = new SelectList(categories, "CategoryId", "Title");
            ViewData["page"] = "categories";
            return Page();
        }

        [BindProperty]
        public ShopCategoryViewModel ShopCategoryViewModel { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (ShopCategoryViewModel.CategoryImageFile != null)
                ShopCategoryViewModel.CategoryImage =
                    _fileManager.SaveFileTo(ShopCategoryViewModel.CategoryImageFile,
                        Directories.CategoryImage);
            await _categoryService.InsertCategory(ShopCategoryViewModel);

            return RedirectToPage("./Index");
        }
    }
}

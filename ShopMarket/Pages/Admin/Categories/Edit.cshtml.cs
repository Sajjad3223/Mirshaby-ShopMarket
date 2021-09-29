using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
    public class EditModel : PageModel
    {
        private readonly IShopCategoryService _categoryService;
        private readonly IFileManager _fileManager;

        public EditModel(IShopCategoryService categoryService, IFileManager fileManager)
        {
            _categoryService = categoryService;
            _fileManager = fileManager;
        }

        [BindProperty]
        public ShopCategoryViewModel ShopCategoryViewModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShopCategoryViewModel = await _categoryService.GetCategory(id.Value);

            if (ShopCategoryViewModel == null)
            {
                return NotFound();
            }

           ViewData["Categories"] = new SelectList(_categoryService.GetAll(), "CategoryId", "Slug");
            return Page();
        }
        

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (ShopCategoryViewModel.CategoryImageFile != null)
                ShopCategoryViewModel.CategoryImage = _fileManager.SaveFileTo(ShopCategoryViewModel.CategoryImageFile,
                    Directories.CategoryImage);
            await _categoryService.UpdateCategory(ShopCategoryViewModel);

            return RedirectToPage("./Index");
        }
    }
}

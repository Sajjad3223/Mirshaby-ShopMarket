using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Security;
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;
using ShopMarket.Domain.ShopEntities;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Pages.Admin.Categories
{
    [BindProperties]
    [PermissionChecker(6)]
    public class DeleteModel : PageModel
    {
        private readonly IShopCategoryService _categoryService;

        public DeleteModel(IShopCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Id = id.Value;
            CategoryName = (await _categoryService.GetCategory(id.Value)).Title;
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _categoryService.DeleteCategory(Id);
            return RedirectToPage("Index");
        }
    }
}

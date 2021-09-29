using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Core.Security;
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;

namespace ShopMarket.Pages.Admin.Products
{
    [PermissionChecker(9)]
    public class DeleteModel : PageModel
    {
        private readonly IProductService _productService;

        public DeleteModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public ProductViewModel ProductViewModel { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
                return NotFound();

            ProductViewModel = await _productService.GetProduct(id.Value);

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            await _productService.DeleteProduct(ProductViewModel.ProductId);

            TempData["Result"] = "کالا با موفقیت غیر فعال گردید";
            return RedirectToPage("Index");
        }
    }
}

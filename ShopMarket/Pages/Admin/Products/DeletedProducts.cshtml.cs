using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopMarket.Core.DTOs;
using ShopMarket.Core.DTOs.ProductDto;
using ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Core.Security;
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;

namespace ShopMarket.Pages.Admin.Products
{
    [PermissionChecker(9)]
    public class DeletedProductsModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IProductImageService _imageService;

        public DeletedProductsModel(IProductService productService, IProductImageService imageService)
        {
            _productService = productService;
            _imageService = imageService;
        }
        
        public IEnumerable<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();

        public async Task<IActionResult> OnGet()
        {
            Products = _productService.GetDeletedProducts().ToList();
            foreach (var product in Products)
            {
                var image = await _imageService.GetMainImage(product.ProductId);
                if(image != null)
                    product.MainImage = image.ImageName;
            }
            return Page();
        }

        public async Task<IActionResult> OnGetReactivate(int id)
        {
            await _productService.ReActivateProduct(id);

            return RedirectToPage("DeleteProducts");
        }
    }
}

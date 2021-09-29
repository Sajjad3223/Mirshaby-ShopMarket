using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopMarket.Core.DTOs;
using ShopMarket.Core.DTOs.ProductDto;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Core.Security;
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;

namespace ShopMarket.Pages.Admin.Products
{
    [PermissionChecker(9)]
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IProductImageService _imageService;

        private readonly IShopCategoryService _categoryService;
        private readonly IStoreService _storeService;

        public IndexModel(IProductService productService, IProductImageService imageService, IShopCategoryService categoryService, IStoreService storeService)
        {
            _productService = productService;
            _imageService = imageService;
            _categoryService = categoryService;
            _storeService = storeService;
        }


        public ProductDto ProductDto { get; set; } = new ProductDto();

        public IEnumerable<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
        
        public ProductFilter Filter { get; set; }

        public async Task<IActionResult> OnGet(ProductFilter filter,string EOrderByType = "Date", string EOrderBy = "Descending")
        {
            ViewData["Stores"] = new SelectList(_storeService.GetAll(), "Id", "StoreName");
            ViewData["Categories"] = new SelectList(_categoryService.GetAll(), "CategoryId", "Title");
            filter.OrderByType = new Tuple<EOrderByType, EOrderBy>(
                Enum.Parse<EOrderByType>(EOrderByType),
                Enum.Parse<EOrderBy>(EOrderBy)
            );
            ProductDto = _productService.GetAll(filter);
            Products = ProductDto.Products.ToList();

            foreach (var product in Products)
            {
                var image = await _imageService.GetMainImage(product.ProductId);
                if(image != null)
                    product.MainImage = image.ImageName;
            }

            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Core.Security;
using ShopMarket.Core.Services.FileManager;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;
using ShopMarket.Domain.ShopEntities;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Pages.Admin.Products
{
    [PermissionChecker(9)]
    public class CreateModel : PageModel
    {
        private readonly IShopCategoryService _categoryService;
        private readonly IStoreService _storeService;
        private readonly IFileManager _fileManager;

        private readonly IProductService _productService;
        private readonly IProductImageService _productImageService;
        private readonly IProductDetailService _productDetailService;

        private readonly IAvailableProductColorService _availableColorService;
        private readonly IAvailableProductSizeService _availableSizeService;

        public CreateModel(IShopCategoryService categoryService, IStoreService storeService, IProductService productService, IProductImageService productImageService, IProductDetailService productDetailService, IAvailableProductColorService availableColorService, IAvailableProductSizeService availableSizeService, IFileManager fileManager)
        {
            _categoryService = categoryService;
            _storeService = storeService;
            _productService = productService;
            _productImageService = productImageService;
            _productDetailService = productDetailService;
            _availableColorService = availableColorService;
            _availableSizeService = availableSizeService;
            _fileManager = fileManager;
        }

        [BindProperty]
        public ProductViewModel ProductViewModel { get; set; }

        public void OnGet()
        {
            ViewData["Stores"] = new SelectList(_storeService.GetAll(),"Id", "StoreName");
            ViewData["Categories"] = new SelectList(_categoryService.GetAll(),"CategoryId","Title");
        }

        public IActionResult OnPost(List<string> availableColors, List<string> availableSizes,List<string> detail_key,List<string> detail_value)
        {
            if (!ModelState.IsValid)
                return Page();

            int productId = _productService.InsertProduct(ProductViewModel);

            if (ProductViewModel.ProductImages != null)
            {
                //Save product Images and add them to database
                foreach (var image in ProductViewModel.ProductImages)
                {
                    string imageName = _fileManager.SaveFileTo(image, Directories.ProductImage + "/" + productId);

                    _productImageService.InsertImage(new ProductImage()
                    {
                        ProductId = productId,
                        IsMainImage = false,
                        ImageName = imageName
                    });
                }
            }

            if (ProductViewModel.MainImageFile != null)
            {
                //Save Main product image and add it to database
                string mainImageName = _fileManager.SaveFileTo(ProductViewModel.MainImageFile, Directories.ProductImage + "/" + productId);
                _productImageService.InsertImage(new ProductImage()
                {
                    ProductId = productId,
                    IsMainImage = true,
                    ImageName = mainImageName
                });
            }


            if(availableColors.Any())
                _availableColorService.InsertColorsToProduct(availableColors, productId);
            if(availableSizes.Any())
                _availableSizeService.InsertSizesToProduct(availableSizes, productId);
            if(detail_key.Any() && detail_value.Any())
                _productDetailService.InsertDetailsToProduct(new Tuple<List<string>, List<string>>(detail_key, detail_value), productId);

            TempData["Result"] = "کالا با موفقیت ثبت گردید";

            return RedirectToPage("Index");
        }
        
    }
}

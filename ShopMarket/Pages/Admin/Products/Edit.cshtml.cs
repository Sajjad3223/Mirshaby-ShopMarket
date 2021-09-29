using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Core.Security;
using ShopMarket.Core.Services.FileManager;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Pages.Admin.Products
{
    [PermissionChecker(9)]
    public class EditModel : PageModel
    {
        private readonly IShopCategoryService _categoryService;
        private readonly IStoreService _storeService;
        private readonly IFileManager _fileManager;

        private readonly IProductService _productService;
        private readonly IProductImageService _productImageService;
        private readonly IProductDetailService _productDetailService;

        private readonly IAvailableProductColorService _availableColorService;
        private readonly IAvailableProductSizeService _availableSizeService;

        public EditModel(IShopCategoryService categoryService, IStoreService storeService, IProductService productService, IProductImageService productImageService, IProductDetailService productDetailService, IAvailableProductColorService availableColorService, IAvailableProductSizeService availableSizeService, IFileManager fileManager)
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

        public FullProductViewModel FullProductViewModel { get; set; } = new FullProductViewModel();
        
        [BindProperty]
        public ProductViewModel ProductViewModel { get; set; }


        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
                return NotFound();

            ViewData["Stores"] = new SelectList(_storeService.GetAll(), "Id", "StoreName");
            ViewData["Categories"] = new SelectList(_categoryService.GetAll(), "CategoryId", "Title");

            ProductViewModel = await _productService.GetProduct(id.Value);

            var image = await _productImageService.GetMainImage(id.Value);
            if(image != null) ProductViewModel.MainImage = image.ImageName;

            FullProductViewModel.Details = _productDetailService.GetProductDetails(id.Value).ToList();

            FullProductViewModel.Images = _productImageService.GetAll(id.Value);

            FullProductViewModel.Colors = _availableColorService.GetAllAvailableColors(id.Value);
            FullProductViewModel.Sizes = _availableSizeService.GetAllAvailableSizes(id.Value);

            return Page();
        }

        public IActionResult OnPost(List<string> availableColors, List<string> availableSizes, List<string> detail_key, List<string> detail_value)
        {
            if (!ModelState.IsValid)
                return Page();

            if (_productService.UpdateProduct(ProductViewModel).Status != OperationResultStatus.Success)
                return Page();

            if(availableColors.Any())
                _availableColorService.UpdateColors(availableColors, ProductViewModel.ProductId);

            if(availableSizes.Any())
                _availableSizeService.UpdateSizes(availableSizes, ProductViewModel.ProductId);

            if(detail_key.Any() && detail_value.Any())
                _productDetailService.UpdateDetails(new Tuple<List<string>, List<string>>(detail_key, detail_value),
                    ProductViewModel.ProductId);
            
            if (ProductViewModel.MainImageFile != null)
            {
                if (ProductViewModel.MainImage != null)
                {
                    _fileManager.DeleteFile(Directories.ProductImage + "/" + ProductViewModel.ProductId,
                        ProductViewModel.MainImage);
                    _productImageService.DeleteImage(ProductViewModel.MainImage);
                }
                string mainImageName = _fileManager.SaveFileTo(ProductViewModel.MainImageFile,
                    Directories.ProductImage + "/" + ProductViewModel.ProductId);
                _productImageService.InsertImage(new ProductImage()
                {
                    ImageName = mainImageName,
                    ProductId = ProductViewModel.ProductId,
                    IsMainImage = true
                });
            }

            FullProductViewModel.Images = _productImageService.GetAll(ProductViewModel.ProductId).Where(i => !i.IsMainImage);
            if (ProductViewModel.ProductImages != null)
            {
                if (FullProductViewModel.Images.Any())
                {
                    FullProductViewModel.Images.ToList().ForEach(pi => _fileManager.DeleteFile(Directories.ProductImage + "/" + ProductViewModel.ProductId,
                        pi.ImageName));
                    FullProductViewModel.Images.ToList().ForEach(pi => _productImageService.DeleteImage(pi));
                }

                ProductViewModel.ProductImages.ForEach(i =>
                {
                    string imageName =
                        _fileManager.SaveFileTo(i, Directories.ProductImage + "/" + ProductViewModel.ProductId);

                    _productImageService.InsertImage(new ProductImage()
                    {
                        ImageName = imageName,
                        ProductId = ProductViewModel.ProductId,
                        IsMainImage = false
                    });
                });
            }

            TempData["Result"] = "کالا با موفقیت ویرایش گردید";
            return RedirectToPage("Index");
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopMarket.Core.DTOs;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;

namespace ShopMarket.ViewComponents.IndexComponents
{
    public class RandomCategoryProductsViewComponent : ViewComponent
    {
        private readonly IMainPageDetailService _detailService;
        private readonly IShopCategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IProductImageService _imageService;

        public RandomCategoryProductsViewComponent(IMainPageDetailService detailService, IShopCategoryService categoryService, IProductService productService, IProductImageService imageService)
        {
            _detailService = detailService;
            _categoryService = categoryService;
            _productService = productService;
            _imageService = imageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryId = _detailService.GetDetails().CategoryIdToShow;
            var category = await _categoryService.GetCategory(categoryId);
            ViewBag.Category = category;
            var products = _productService.GetProductsByCategory(categoryId, new ProductFilter()).Products.Take(10).ToList();
            var subCategories = _categoryService.GetSubCategories(category.CategoryId);
            if (subCategories.Any())
            {
                List<ProductViewModel> childProducts = new List<ProductViewModel>();
                foreach (var sub in subCategories)
                {
                    childProducts = childProducts.Union(_productService.GetProductsByCategory(sub.CategoryId, new ProductFilter()).Products).ToList();
                }

                products = products.Union(childProducts).GroupBy(p => p.ProductId).Select(y => y.FirstOrDefault()).ToList();
            }
            foreach (var product in products)
            {
                var image = await _imageService.GetMainImage(product.ProductId);
                product.MainImage = image.ImageName;
            }
            return View(products);
        }
    }
}
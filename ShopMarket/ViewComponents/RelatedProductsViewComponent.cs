using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopMarket.Core.DTOs;
using ShopMarket.Core.DTOs.ProductDto;
using ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;
using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.ViewComponents
{
    public class RelatedProductsViewComponent : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IProductImageService _imageService;

        public RelatedProductsViewComponent(IProductService productService, IProductImageService imageService)
        {
            _productService = productService;
            _imageService = imageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int categoryId , string Tags)
        {
            ProductDto productDto = new ProductDto();
            if (categoryId != 0)
                productDto = _productService.GetProductsByCategory(categoryId, new ProductFilter());
            else
                productDto = _productService.GetAll(new ProductFilter());
            productDto.Products = productDto.Products.Where(p => p.Tags.Contains(Tags)).Take(7);
            var products = productDto.Products.ToList();
            foreach (var product in products)
            {
                var image = await _imageService.GetMainImage(product.ProductId);
                product.MainImage = image.ImageName;
            }
            productDto.Products = products;
            return View(productDto);
        }
    }
}

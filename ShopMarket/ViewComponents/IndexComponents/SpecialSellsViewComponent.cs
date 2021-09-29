using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces;

namespace ShopMarket.ViewComponents.IndexComponents
{
    public class SpecialSellsViewComponent : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IProductImageService _imageService;

        public SpecialSellsViewComponent(IProductService productService, IProductImageService imageService)
        {
            _productService = productService;
            _imageService = imageService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = _productService.GetSpecialProducts().ToList();
            foreach (var product in products)
            {
                var image = await _imageService.GetMainImage(product.ProductId);
                if(image != null)
                    product.MainImage = image.ImageName;
            }
            return View(products);
        }
    }
}
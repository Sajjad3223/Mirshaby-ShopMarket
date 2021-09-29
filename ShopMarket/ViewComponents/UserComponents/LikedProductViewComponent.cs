using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.ViewComponents
{
    public class LikedProductViewComponent : ViewComponent
    {
        private readonly ILikedProductService _likedService;
        private readonly IProductImageService _imageService;
        private readonly IProductService _productService;

        public LikedProductViewComponent(ILikedProductService likedService, IProductImageService imageService, IProductService productService)
        {
            _likedService = likedService;
            _imageService = imageService;
            _productService = productService;
        }


        public async Task<IViewComponentResult> InvokeAsync(int likedProductId,int productId)
        {
            LikedProductViewModel likedProductVM = new LikedProductViewModel();

            ProductViewModel product = await _productService.GetProduct(productId);

            likedProductVM.Title = product.Title;
            likedProductVM.Price = PriceCalculator.CalculateDiscountPrice(product.Price, product.Discount);
            likedProductVM.Score = product.Score;
            likedProductVM.LikedId = likedProductId;
            likedProductVM.ProductId = productId;

            likedProductVM.MainImageName = (await _imageService.GetMainImage(productId)).ImageName;

            return View(likedProductVM);
        }
    }
}
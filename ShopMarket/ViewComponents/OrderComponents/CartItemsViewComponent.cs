using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.ViewModels.ShopViewModels.OrderViewModels;
using ShopMarket.Domain.Interfaces.ShopInterfaces;
using ShopMarket.Domain.Interfaces.ShopInterfaces.OrderInterfaces;

namespace ShopMarket.ViewComponents
{
    public class CartItemsViewComponent : ViewComponent
    {
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;
        private readonly IProductImageService _imageService;
        private readonly IStoreRepository _storeRepository;

        public CartItemsViewComponent(IOrderService orderService, IOrderItemService orderItemService, IProductImageService imageService, IStoreRepository storeRepository)
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
            _imageService = imageService;
            _storeRepository = storeRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int OrderId)
        {
            OrderViewModel openOrder = null;
            openOrder = await _orderService.GetOrder(OrderId);

            List<CartItemViewModel> cartItems = new List<CartItemViewModel>();

            if (openOrder != null)
            {
                var orderItems = _orderItemService.GetItemsOfOrder(openOrder.OrderId).ToList();

                foreach (var oi in orderItems)
                {
                    cartItems.Add(new CartItemViewModel()
                    {
                        ItemId = oi.OrderItemId,
                        ProductId = oi.ProductId,
                        Title = oi.Product.Title,
                        MainImage = (await _imageService.GetMainImage(oi.ProductId)).ImageName,
                        Price = PriceCalculator.CalculateDiscountPrice(oi.Product.Price,oi.Product.Discount),
                        Count = oi.Count,
                        Remaining = oi.Product.Remaining,
                        SellerName = (await _storeRepository.GetStore(oi.Product.StoreId)).StoreName,
                        Color = oi.Color,
                        Size = oi.Size
                    });
                }
            }

            return View(cartItems);
        }
    }
}
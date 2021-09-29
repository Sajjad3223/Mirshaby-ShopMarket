using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.ViewModels.ShopViewModels.OrderViewModels;
using ShopMarket.Domain.Interfaces.ShopInterfaces.OrderInterfaces;

namespace ShopMarket.ViewComponents
{
    public class OrderDetailItems : ViewComponent
    {
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;
        private readonly IProductImageService _imageService;
        private readonly IStoreService _storeService;

        public OrderDetailItems(IOrderService orderService, IOrderItemService orderItemService, IProductImageService imageService, IStoreService storeService)
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
            _imageService = imageService;
            _storeService = storeService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int orderId)
        {
            List<OrderDetailItem> orderItems = new List<OrderDetailItem>();
            var items = _orderItemService.GetItemsOfOrder(orderId).ToList();
            
            foreach(var i in items)
            {
                string imageName = (await _imageService.GetMainImage(i.ProductId)).ImageName;
                string storeName = (await _storeService.GetStore(i.Product.StoreId)).StoreName;
                orderItems.Add(new OrderDetailItem()
                {
                    ImageName = imageName,
                    Color = i.Color,
                    Size = i.Size,
                    Price = i.Price.Value * i.Count,
                    Count = i.Count,
                    ProductId = i.ProductId,
                    SellerName = storeName,
                    Title = i.Product.Title
                });
            }

            return View(orderItems);
        }
    }
}
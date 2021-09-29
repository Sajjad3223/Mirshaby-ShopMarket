using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.ViewModels.ShopViewModels.OrderViewModels;
using ShopMarket.Domain.Interfaces.ShopInterfaces.OrderInterfaces;

namespace ShopMarket.ViewComponents
{
    public class OrderPricesViewComponent : ViewComponent
    {
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _itemService;

        public OrderPricesViewComponent(IOrderService orderService, IOrderItemService itemService)
        {
            _orderService = orderService;
            _itemService = itemService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int OrderId)
        {
            OrderViewModel order = await _orderService.GetOrder(OrderId);
            var orderItems = _itemService.GetItemsOfOrder(order.OrderId);
            ViewBag.ItemsCount = orderItems.Count();
            if (orderItems.Any())
            {
                ViewBag.ItemsDiscountPercent = 0;

                order.TotalPrice = orderItems.Sum(i => i.Product.Price * i.Count);
                int discountPrice = 0;
                orderItems.Where(i => i.Product.Discount.HasValue).ToList().ForEach(i =>
                {
                    discountPrice += (int)(((i.Product.Price * i.Product.Discount) / 100) * i.Count);
                });
                order.ItemsDiscount = discountPrice;
                ViewBag.ItemsDiscountPercent = ((discountPrice * 100) / order.TotalPrice);

                var sumPrice = order.TotalPrice - discountPrice;

                order.FinalPrice = PriceCalculator.CalculateDiscountPrice(sumPrice, order.Discount);
                ViewBag.OrderDiscountValue = (int)((sumPrice * order.Discount.Value) / 100);
            }
            return View(order);
        }
    }
}
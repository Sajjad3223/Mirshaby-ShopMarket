using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ShopMarket.Core.Interfaces;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.ViewModels.ShopViewModels.OrderViewModels;
using ShopMarket.Domain.Interfaces.ShopInterfaces.OrderInterfaces;
using ZarinpalSandbox;

namespace ShopMarket.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;
        private readonly IDiscountCodeService _discountCode;
        private readonly IUserService _userService;
        private readonly IUserAddressService _addressService;
        private readonly IOrderHandler _orderHandler;


        public OrderController(IOrderService orderService, IDiscountCodeService discountCode, IUserService userService, IUserAddressService addressService, IOrderHandler orderHandler, IOrderItemService orderItemService)
        {
            _orderService = orderService;
            _discountCode = discountCode;
            _userService = userService;
            _addressService = addressService;
            _orderHandler = orderHandler;
            _orderItemService = orderItemService;
        }

        public async Task<IActionResult> ShowOrder()
        {
            int userId = User.GetUserId();
            int OrderId = 0;

            if (await _orderService.HasOpenOrder(userId))
                OrderId = (await _orderService.GetUserOpenOrder(userId)).OrderId;

            return View(OrderId);
        }

        public async Task<IActionResult> PayAndSendMethod(int orderId)
        {
            int userId = User.GetUserId();
            var order = await _orderService.GetOrder(orderId);
            if (order == null)
                return NotFound();
            if (order.UserId != userId)
                return NotFound();

            return View(order);
        }

        [Route("/order/ApplyDiscount/{orderId}/{discountCode}")]
        public async Task<IActionResult> ApplyDiscount(int orderId, string discountCode)
        {
            var order = await _orderService.GetOrder(orderId);
            if (order == null)
                return NotFound();
            if (await _discountCode.DoesCodeExist(discountCode))
            {
                if (!await _discountCode.IsCodeExpired(discountCode) && !await _discountCode.IsCodeUsed(discountCode))
                {
                    var discount = await _discountCode.GetCode(discountCode);
                    if (order.Discount.Value == 0)
                    {
                        order.Discount = discount.Discount;

                        _orderService.UpdateOrder(order);

                        var result = await _discountCode.UseDiscountCode(discountCode);
                        if (result.Status != OperationResultStatus.Success)
                            return null;
                    }

                    return null;
                }
            }

            return ViewComponent("OrderPrices",new
            {
                OrderId = orderId
            });
        }

        public async Task<IActionResult> SubmitAndPay(int orderId)
        {
            await UpdateOrder(orderId);
            var order = await _orderService.GetOrder(orderId);
            var user = await _userService.GetUser(User.GetUserId());
            var addressId = (await _addressService.GetUserActiveAddress(user.UserId)).AddressId;
            order.ReceiverAddressId = addressId;
            _orderService.UpdateOrder(order);

            var payment = new Payment(order.FinalPrice);

            var response = payment.PaymentRequest($"پرداخت فاکتور شماره {order.OrderId}",
                $"{Directories.DOMAIN}Order/OrderPayment/{order.OrderId}",
                user.Email,
                user.PhoneNumber);

            if (response.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + response.Result.Authority);
            }
            else
                return RedirectToAction("PaymentFailed",order);
        }

        async Task<OrderViewModel> UpdateOrder(int orderId)
        {
            var order = await _orderService.GetOrder(orderId);
            var orderItems = _orderItemService.GetItemsOfOrder(order.OrderId);

            order.TotalPrice = orderItems.Sum(i => i.Product.Price * i.Count);
            int discountPrice = 0;
            orderItems.Where(i => i.Product.Discount.HasValue).ToList().ForEach(i =>
            {
                discountPrice += (int)(((i.Product.Price * i.Product.Discount) / 100) * i.Count);
            });

            var sumPrice = order.TotalPrice - discountPrice;

            order.FinalPrice = PriceCalculator.CalculateDiscountPrice(sumPrice, order.Discount);
            _orderService.UpdateOrder(order);
            return order;
        }

        public async Task<IActionResult> OrderPayment(int id)
        {
            var order = await _orderService.GetOrder(id);
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"].ToString();
                Payment payment = new Payment(order.FinalPrice);
                var response = payment.Verification(authority);

                if (response.Result.Status == 100)
                {
                    await _orderHandler.FinalizeOrder(order.OrderId, response.Result.RefId);
                    
                    ViewBag.RefId = response.Result.RefId;
                    return View(order);
                }
            }

            return RedirectToAction("PaymentFailed",order);
        }

        public IActionResult PaymentFailed(OrderViewModel order)
        {
            return View(order);
        }
    }
}

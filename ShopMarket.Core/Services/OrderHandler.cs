using System;
using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.Interfaces;
using ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.Interfaces.ShopInterfaces.OrderInterfaces;

namespace ShopMarket.Core.Services
{
    public class OrderHandler : IOrderHandler
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _itemService;

        public OrderHandler(IProductService productService, IOrderService orderService, IOrderItemService itemService)
        {
            _productService = productService;
            _orderService = orderService;
            _itemService = itemService;
        }
        public async Task<OperationResult> FinalizeOrder(int orderId,long refId)
        {
            try
            {
                var order = await _orderService.GetOrder(orderId);

                _orderService.FinializeOrder(order,refId);

                var items = _itemService.GetItemsOfOrder(orderId).ToList();

                foreach (var item in items)
                {
                    item.Price = PriceCalculator.CalculateDiscountPrice(item.Product.Price, item.Product.Discount);
                    _itemService.UpdateOrderItem(item);
                }
                
                _productService.DecreaseProductsCount(items);

                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }
    }
}
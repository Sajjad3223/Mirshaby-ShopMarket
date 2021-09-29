using ShopMarket.Core.ViewModels.ShopViewModels.OrderViewModels;
using ShopMarket.Domain.ShopEntities.OrderEntities;

namespace ShopMarket.Core.Utilities.Mappers
{
    public static class OrderMapper
    {
        public static OrderViewModel MapToViewModel(this Order order)
        {
            return new OrderViewModel()
            {
                UserId = order.UserId,
                OrderId = order.Id,
                CreationDate = order.CreationDate,
                Discount = order.Discount,
                OrderStatus = order.OrderStatus,
                FinalPrice = order.FinalPrice,
                ReceiverAddressId = order.ReceiverAddressId,
                RefId = order.RefId
            };
        }

        public static Order MapToOrder(this OrderViewModel orderViewModel)
        {
            return new Order()
            {
                UserId = orderViewModel.UserId,
                Id = orderViewModel.OrderId,
                CreationDate = orderViewModel.CreationDate,
                Discount = orderViewModel.Discount,
                OrderStatus = orderViewModel.OrderStatus,
                FinalPrice = orderViewModel.FinalPrice,
                ReceiverAddressId = orderViewModel.ReceiverAddressId,
                RefId = orderViewModel.RefId
            };
        }
    }
}
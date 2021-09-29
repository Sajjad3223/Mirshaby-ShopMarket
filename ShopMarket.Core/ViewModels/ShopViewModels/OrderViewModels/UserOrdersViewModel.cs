using System.Collections.Generic;
using ShopMarket.Domain.ShopEntities.OrderEntities;

namespace ShopMarket.Core.ViewModels.ShopViewModels.OrderViewModels
{
    public class UserOrdersViewModel
    {
        public IEnumerable<OrderViewModel> NotPaidOrders { get; set; } = new List<OrderViewModel>();
        public IEnumerable<OrderViewModel> PaidOrders { get; set; } = new List<OrderViewModel>();
        public IEnumerable<OrderViewModel> IsSendingOrders { get; set; } = new List<OrderViewModel>();
        public IEnumerable<OrderViewModel> DeliveredOrders { get; set; } = new List<OrderViewModel>();
    }
}
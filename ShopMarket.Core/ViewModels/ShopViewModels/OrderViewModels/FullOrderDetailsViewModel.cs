using System;
using System.Collections.Generic;
using ShopMarket.Core.ViewModels.UserViewModels;
using ShopMarket.Domain.ShopEntities.OrderEntities;

namespace ShopMarket.Core.ViewModels.ShopViewModels.OrderViewModels
{
    public class FullOrderDetailsViewModel
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public UserAddressViewModel Address { get; set; }
        public DateTime CreationDate { get; set; }
        public EOrderStatus OrderStatus { get; set; }
        public float? Discount { get; set; }
        public int FinalPrice { get; set; }
        public long? RefId { get; set; }
    }
}
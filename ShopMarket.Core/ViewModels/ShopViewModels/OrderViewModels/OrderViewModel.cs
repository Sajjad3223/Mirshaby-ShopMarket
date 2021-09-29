using System;
using System.Collections.Generic;
using ShopMarket.Domain.ShopEntities.OrderEntities;

namespace ShopMarket.Core.ViewModels.ShopViewModels.OrderViewModels
{
    public class OrderViewModel
    {
        public int UserId { get; set; }

        public int OrderId { get; set; }

        public float? Discount { get; set; } = 0;

        public float? ItemsDiscount { get; set; } = 0;

        public int? ReceiverAddressId { get; set; }
        
        public int TotalPrice { get; set; }

        public int FinalPrice { get; set; }

        public DateTime CreationDate { get; set; }

        public EOrderStatus OrderStatus { get; set; }

        public long? RefId { get; set; }
        
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShopMarket.Domain.BaseEntities;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Domain.ShopEntities.OrderEntities
{
    public class Order : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        
        public float? Discount { get; set; }
        
        public int? ReceiverAddressId { get; set; }

        [Required]
        public int FinalPrice { get; set; }

        [Required] 
        public EOrderStatus OrderStatus { get; set; } = EOrderStatus.NotPaid;

        public long? RefId { get; set; }
        
        #region Relations

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("ReceiveAddressId")]
        public UserAddress UserAddress { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        #endregion
    }
}
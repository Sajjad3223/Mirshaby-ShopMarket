using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShopMarket.Domain.ShopEntities.OrderEntities;

namespace ShopMarket.Domain.UserEntities
{
    public class UserAddress
    {
        [Key]
        public int AddressId { get; set; }
        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(30)]
        public string ReceiverName { get; set; }

        [Required]
        [StringLength(11)]
        public string ReceiverPhone { get; set; }

        [Required]
        [MaxLength(30)]
        public string State { get; set; }
        [Required]
        [MaxLength(30)]
        public string City { get; set; }
        [Required]
        [MaxLength(100)]
        public string Street { get; set; }
        [Required]
        [MaxLength(300)]
        public string FullAddress { get; set; }
        [Required]
        public int Plaque { get; set; }

        public bool IsSelectedAddress { get; set; } = false;


        #region Relations

        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<Order> Orders { get; set; }

        #endregion
    }
}

using System.ComponentModel.DataAnnotations;

namespace ShopMarket.Core.ViewModels.UserViewModels
{
    public class UserAddressViewModel
    {
        public int AddressId { get; set; }
        
        public int UserId { get; set; }

        [Required]
        [MaxLength(30)]
        public string ReceiverName { get; set; }

        [Required]
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
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
        [DataType(DataType.MultilineText)]
        public string FullAddress { get; set; }

        [Required]
        public int Plaque { get; set; }

        public bool IsSelectedAddress { get; set; }
    }
}

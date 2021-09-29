using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ShopMarket.Domain.BaseEntities;
using ShopMarket.Domain.ShopEntities;
using ShopMarket.Domain.ShopEntities.OrderEntities;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Domain.UserEntities
{
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [MaxLength(10)]
        public string? NationalCode { get; set; }

        [Display(Name = "کد فعال سازی")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ActiveCode { get; set; }

        [Display(Name = "آواتار")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserAvatar { get; set; }

        public bool ReceiveNews { get; set; } = false;

        public bool IsEmailVerified { get; set; } = false;

        #region Relations

        public ICollection<Store> Stores { get; set; }
        public ICollection<ProductComment> ProductComments { get; set; }
        public ICollection<UserAddress> UserAddresses { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<LikedProduct> LikedProducts { get; set; }
        public ICollection<RecentVisit> RecentVisits { get; set; }
        public ICollection<Order> Orders { get; set; }

        #endregion
    }
}
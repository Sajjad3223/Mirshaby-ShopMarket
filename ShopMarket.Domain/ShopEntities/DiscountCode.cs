using System;
using System.ComponentModel.DataAnnotations;

namespace ShopMarket.Domain.ShopEntities
{
    public class DiscountCode
    {
        [Key]
        public int DiscountCodeId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "کد تخفیف")]
        public string Code { get; set; }
        [Required]
        [Display(Name = "مبلغ تخفیف")]
        public float Discount { get; set; }

        [Required]
        [Display(Name = "تعداد تخفیف")]
        public int CodeCount { get; set; } = 1;

        [Required]
        [Display(Name = "تاریخ انقضا")]
        public DateTime ExpireTime { get; set; }

        public bool IsUsed { get; set; } = false;
    }
}
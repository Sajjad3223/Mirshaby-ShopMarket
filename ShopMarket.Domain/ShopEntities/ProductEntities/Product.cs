
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShopMarket.Domain.BaseEntities;

namespace ShopMarket.Domain.ShopEntities.ProductEntities
{
    public class Product : BaseEntity
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int StoreId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        
        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Remaining { get; set; }

        public float? Discount { get; set; }

        public int? DiscountCount { get; set; }

        public DateTime? DiscountExpireTime { get; set; }

        public int Score { get; set; } = 0;

        public int Visit { get; set; } = 0;

        [MaxLength(5)]
        public string? ShortLink { get; set; }

        public bool ShowInSlider { get; set; } = false;

        public string? Tags { get; set; }

        #region Relations

        public ICollection<ProductImage> ProductImages { get; set; }

        public ICollection<AvailableProductColor> AvailableProductColors { get; set; }

        public ICollection<AvailableProductSize> AvailableProductSizes { get; set; }

        public ICollection<ProductDetail> ProductDetails { get; set; }

        public ICollection<ProductComment> ProductComments { get; set; }

        [ForeignKey("CategoryId")]
        public ShopCategory ShopCategory { get; set; }

        [ForeignKey("StoreId")]
        public Store Store  { get; set; }

        #endregion
    }
}

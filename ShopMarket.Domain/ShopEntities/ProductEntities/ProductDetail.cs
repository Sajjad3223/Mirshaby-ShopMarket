using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMarket.Domain.ShopEntities.ProductEntities
{
    public class ProductDetail
    {
        [Key]
        public int ProductDetailId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Key { get; set; }

        [Required]
        [MaxLength(200)]
        public string Value { get; set; }

        #region Relations

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        #endregion
    }
}
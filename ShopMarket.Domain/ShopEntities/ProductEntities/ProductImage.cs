using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMarket.Domain.ShopEntities.ProductEntities
{
    public class ProductImage
    {
        [Key]
        [MaxLength(50)]
        public string ImageName { get; set; }

        [Required]
        public int  ProductId { get; set; }

        public bool IsMainImage { get; set; } = false;

        #region Relations

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        #endregion
    }
}
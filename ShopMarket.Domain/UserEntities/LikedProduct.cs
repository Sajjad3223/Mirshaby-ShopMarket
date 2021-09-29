using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Domain.UserEntities
{
    public class LikedProduct
    {
        [Key]
        public int LikedProductId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProductId { get; set; }

        #region Relations

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        #endregion
    }
}
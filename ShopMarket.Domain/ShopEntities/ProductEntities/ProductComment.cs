using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShopMarket.Domain.BaseEntities;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Domain.ShopEntities.ProductEntities
{
    public class ProductComment : BaseEntity
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(600)]
        public string Text { get; set; }

        [Required]
        public int Score { get; set; }

        #region Relations

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        #endregion
    }
}
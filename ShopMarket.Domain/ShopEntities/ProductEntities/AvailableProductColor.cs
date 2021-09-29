using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMarket.Domain.ShopEntities.ProductEntities
{
    public class AvailableProductColor
    {
        [Key]
        public int AvaiableColorId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public EColor Color { get; set; }

        #region Relations

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        #endregion
    }
}
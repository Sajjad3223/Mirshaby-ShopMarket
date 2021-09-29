using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMarket.Domain.ShopEntities.ProductEntities
{
    public class AvailableProductSize
    {
        [Key]
        public int AvaiableSizeId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public ESize Size { get; set; }

        #region Relations

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        #endregion
    }
}
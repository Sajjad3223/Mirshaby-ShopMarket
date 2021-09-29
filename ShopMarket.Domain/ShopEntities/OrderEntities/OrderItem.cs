using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Domain.ShopEntities.OrderEntities
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Count { get; set; }

        public int? Price { get; set; }

        public EColor? Color { get; set; }

        public ESize? Size { get; set; }

        #region Relations

        [ForeignKey("OrderId")] 
        public Order Order { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        #endregion
    }
}
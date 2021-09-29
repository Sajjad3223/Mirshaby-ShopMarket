using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShopMarket.Domain.BaseEntities;
using ShopMarket.Domain.ShopEntities.ProductEntities;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Domain.ShopEntities
{
    public class Store : BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string StoreName { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string StoreDescription { get; set; }
        
        [MaxLength(50)]
        public string StoreImageName { get; set; }
        
        [MaxLength(200)]
        public string StoreAddress { get; set; }

        #region Relations
        
        public ICollection<Product> Products { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        #endregion
    }
}
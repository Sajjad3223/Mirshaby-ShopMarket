using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopMarket.Domain.BaseEntities;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Domain.ShopEntities
{
    public class ShopCategory : BaseEntity
    {
        public int? ParentId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Slug { get; set; }
        
        [MaxLength(50)]
        public string? CategoryImage { get; set; }

        public bool ShowInMainPage { get; set; } = false;

        #region Relations

        [ForeignKey("ParentId")]
        public ShopCategory ParentCategory { get; set; }

        public ICollection<Product> Products { get; set; }

        #endregion

    }
}

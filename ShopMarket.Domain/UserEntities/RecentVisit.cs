using System.ComponentModel.DataAnnotations.Schema;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Domain.UserEntities
{
    public class RecentVisit
    {
        public int RecentVisitId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }

        #region Relations

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        #endregion
    }
}
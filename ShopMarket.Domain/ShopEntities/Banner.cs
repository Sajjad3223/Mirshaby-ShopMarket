using System.ComponentModel.DataAnnotations;

namespace ShopMarket.Domain.ShopEntities
{
    public class Banner
    {
        [Key]
        public int BannerId { get; set; }
        [Required]
        [MaxLength(50)]
        public string BannerImage { get; set; }
        [Required]
        [MaxLength(100)]
        public string BannerLink { get; set; }
    }
}
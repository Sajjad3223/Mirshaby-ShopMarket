using System.ComponentModel.DataAnnotations;

namespace ShopMarket.Domain.ShopEntities
{
    public class Slide
    {
        [Key]
        public int SlideId { get; set; }
        [Required]
        [MaxLength(50)]
        public string SlideImage { get; set; }
        [Required]
        [MaxLength(100)]
        public string SlideContent { get; set; }
        [Required]
        [MaxLength(100)]
        public string SlideLink { get; set; }
    }
}
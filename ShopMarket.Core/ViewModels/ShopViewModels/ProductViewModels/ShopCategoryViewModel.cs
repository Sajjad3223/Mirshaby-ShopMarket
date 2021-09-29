using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using ShopMarket.Core.Utilities;

namespace ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels
{
    public class ShopCategoryViewModel
    {
        public int CategoryId { get; set; }

        public int? ParentId { get; set; }

        [Required]
        [Display(Name = "عنوان دسته بندی")]
        [MaxLength(200)]
        public string Title { get; set; }

        public string Slug => Title.ToSlug();
        
        [MaxLength(50)] 
        public string CategoryImage { get; set; } = "default.png";
        
        [Display(Name = "تصویر دسته بندی")]
        public IFormFile CategoryImageFile { get; set; }

        [Display(Name = "نمایش در صفحه اصلی؟")]
        public bool ShowInMainPage { get; set; } = false;

        public DateTime CreationDate { get; set; }
        
    }
}
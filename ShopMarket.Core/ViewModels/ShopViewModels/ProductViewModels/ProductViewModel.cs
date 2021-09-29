using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.ShopEntities;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [Display(Name = "فروشگاه")]
        public int StoreId { get; set; }

        [Display(Name = "دسته بندی")]
        public int CategoryId { get; set; }

        [Display(Name = "عنوان کالا")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Slug => Title.ToSlug();

        [Display(Name = "توضیحات کالا")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        [Display(Name = "قیمت کالا")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Price { get; set; }
        
        public string MainImage { get; set; }

        [Display(Name = "تصویر اصلی")]
        public IFormFile MainImageFile { get; set; }

        [Display(Name = "تصاویر دیگر")]
        public List<IFormFile> ProductImages { get; set; }

        [Display(Name = "کلمات کلیدی")]
        public string Tags { get; set; } = "";
        
        public string? ShortLink { get; set; }

        [Display(Name = "موجودی انبار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Remaining { get; set; }

        [Display(Name = "تخفیف به درصد")]
        public float? Discount { get; set; }

        [Display(Name = "امتیاز کالا")]
        public int Score { get; set; } = 0;

        [Display(Name = "تعداد بازدید")]
        public int Visit { get; set; } = 0;


        [Display(Name = "تعداد تخفیف")]
        public int? DiscountCount { get; set; }

        [Display(Name = "نمایش در اسلایدر؟")]
        public bool ShowInSlider { get; set; } = false;

        public DateTime CreationDate { get; set; }
    }
}
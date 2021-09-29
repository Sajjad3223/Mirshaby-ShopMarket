using System;
using System.ComponentModel.DataAnnotations;
using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Core.DTOs
{
    public class Filter
    {
        public string Search { get; set; } = "";
        public int Take { get; set; } = 20;
        public int PageId { get; set; } = 1;
    }

    public class ProductFilter
    {
        [Display(Name = "جستجو: عنوان ، کلمه کلیدی ، توضیحات")]
        public string Search { get; set; } = "";
        [Display(Name = "تعداد نتایج در هر صفحه")]
        public int Take { get; set; } = 12;

        public int PageId { get; set; } = 1;
        [Display(Name = "مرتب سازی بر اساس")]
        public Tuple<EOrderByType,EOrderBy> OrderByType { get; set; }
        [Display(Name = "فقط کالا های موجود")]
        public bool JustIsAvailable { get; set; } = false;
        [Display(Name = "دسته بندی")]
        public int? CategoryId { get; set; }
        [Display(Name = "فروشگاه")]
        public int? StoreId { get; set; }
        [Display(Name = "حداکثر موجودی در انبار")]
        public int? Remaining { get; set; }
        [Display(Name = "حداقل قیمت")]
        public int? MinimumPrice { get; set; }
        [Display(Name = "حداکثر قیمت")]
        public int? MaximumPrice { get; set; }
        [Display(Name = "رنگ")]
        public EColor? Color { get; set; }
        [Display(Name = "اندازه")]
        public ESize? Size { get; set; }

    }

    public enum EOrderByType
    {
        Date,
        Price,
        Score,
        Visit
    }

    public enum EOrderBy
    {
        Ascending,
        Descending
    }
}
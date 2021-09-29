using System.Collections.Generic;
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;

namespace ShopMarket.Core.DTOs.ProductDto
{
    public class ShopCategoryDto
    {
        public IEnumerable<ShopCategoryViewModel> ShopCategories { get; set; }
    }
}
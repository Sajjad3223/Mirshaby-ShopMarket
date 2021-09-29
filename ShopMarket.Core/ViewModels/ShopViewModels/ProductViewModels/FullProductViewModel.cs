using System.Collections.Generic;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels
{
    public class FullProductViewModel
    {
        public ProductViewModel ProductViewModel { get; set; }

        public IEnumerable<ProductImage> Images { get; set; }

        public IEnumerable<ProductDetail> Details { get; set; }

        public IEnumerable<AvailableProductColor>? Colors { get; set; }
        public IEnumerable<AvailableProductSize>? Sizes { get; set; }

    }
}
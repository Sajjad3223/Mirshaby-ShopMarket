using System.Collections.Generic;
using ShopMarket.Core.DTOs.UserDTOs;
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;
using ShopMarket.Domain.ShopEntities;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Core.DTOs.ProductDto
{
    public class ProductDto
    {
        public int PageCount { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
        public ProductFilter Filter { get; set; }
    }
}
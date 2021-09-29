using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopMarket.Core.Utilities;

namespace ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels
{
    public class LikedProductViewModel
    {
        public int LikedId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Slug => Title.ToSlug();
        public string MainImageName { get; set; }
        public int Score { get; set; }
        public int Price { get; set; }
    }
}

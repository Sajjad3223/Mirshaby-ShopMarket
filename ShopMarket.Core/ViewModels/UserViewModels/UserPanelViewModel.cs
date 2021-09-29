using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopMarket.Core.ViewModels.ShopViewModels.OrderViewModels;
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;
using ShopMarket.Domain.ShopEntities.OrderEntities;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Core.ViewModels.UserViewModels
{
    public class UserPanelViewModel
    {
        public UserViewModel User { get; set; }

        public IEnumerable<LikedProductViewModel> LikedProducts { get; set; }

        public IEnumerable<OrderViewModel> Orders { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopMarket.Core.Security;
using ShopMarket.Core.ViewModels.ShopViewModels.OrderViewModels;
using ShopMarket.Domain.Interfaces.ShopInterfaces.OrderInterfaces;

namespace ShopMarket.Pages.Admin.Orders
{
    [PermissionChecker(10)]
    public class IndexModel : PageModel
    {
        private readonly IOrderService _orderService;

        public IndexModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IList<OrderViewModel> Orders { get; set; }

        public void OnGet()
        {
            Orders = _orderService.GetAll().ToList();
        }
    }
}

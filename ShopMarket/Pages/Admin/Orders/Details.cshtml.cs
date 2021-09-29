using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopMarket.Core.Security;
using ShopMarket.Domain.Interfaces.ShopInterfaces.OrderInterfaces;
using ShopMarket.Domain.ShopEntities.OrderEntities;

namespace ShopMarket.Pages.Admin.Orders
{
    [PermissionChecker(10)]
    public class DetailsModel : PageModel
    {
        private readonly IOrderItemService _orderItemService;

        public DetailsModel(IOrderService orderService, IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        public IList<OrderItem> OrderItems { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
                return NotFound();
            OrderItems = _orderItemService.GetItemsOfOrder(id.Value).ToList();

            return Page();
        }
    }
}

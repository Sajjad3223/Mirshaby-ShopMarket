using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Security;
using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Pages.Admin.DiscountCodes
{
    [PermissionChecker(1002)]
    public class IndexModel : PageModel
    {
        private readonly IDiscountCodeService _discountCodeService;

        public IndexModel(IDiscountCodeService discountCodeService)
        {
            _discountCodeService = discountCodeService;
        }

        public IList<DiscountCode> DiscountCodes { get; set; }

        public void OnGet()
        {
            DiscountCodes = _discountCodeService.GetAll().ToList();
        }
    }
}

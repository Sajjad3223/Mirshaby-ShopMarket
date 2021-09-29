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
    public class CreateModel : PageModel
    {
        private readonly IDiscountCodeService _discountCodeService;

        public CreateModel(IDiscountCodeService discountCodeService)
        {
            _discountCodeService = discountCodeService;
        }

        [BindProperty]
        public DiscountCode DiscountCode { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _discountCodeService.InsertCode(DiscountCode);

            return RedirectToPage("Index");

        }
    }
}

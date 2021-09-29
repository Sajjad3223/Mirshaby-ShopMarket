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
    public class DeleteModel : PageModel
    {
        private readonly IDiscountCodeService _discountCodeService;

        public DeleteModel(IDiscountCodeService discountCodeService)
        {
            _discountCodeService = discountCodeService;
        }

        [BindProperty]
        public DiscountCode DiscountCode { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();
            DiscountCode = await _discountCodeService.GetCode(id.Value);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (DiscountCode.DiscountCodeId == default)
                return Page();

            _discountCodeService.DeleteCode(DiscountCode);

            return RedirectToPage("Index");

        }
    }
}

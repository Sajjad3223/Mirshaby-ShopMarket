using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Security;
using ShopMarket.Domain.ShopEntities;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Pages.Admin.Stores
{
    [PermissionChecker(7)]
    public class DetailsModel : PageModel
    {
        private readonly IStoreService _storeService;

        public DetailsModel( IStoreService storeService)
        {
            _storeService = storeService;
        }

        public Store Store { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Store = await _storeService.GetStore(id.Value);

            if (Store == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

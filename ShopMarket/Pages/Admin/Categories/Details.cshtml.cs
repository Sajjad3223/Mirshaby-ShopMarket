using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Core.Security;
using ShopMarket.Domain.ShopEntities;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Pages.Admin.Categories
{
    [PermissionChecker(6)]
    public class DetailsModel : PageModel
    {
        private readonly ShopMarket.Infra.Data.ShopMarketContext.ShopMarketDbContext _context;

        public DetailsModel(ShopMarket.Infra.Data.ShopMarketContext.ShopMarketDbContext context)
        {
            _context = context;
        }

        public ShopCategory ShopCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShopCategory = await _context.ShopCategories
                .Include(s => s.ParentCategory).FirstOrDefaultAsync(m => m.Id == id);

            if (ShopCategory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

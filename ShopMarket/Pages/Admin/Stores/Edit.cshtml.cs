using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Core.DTOs;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Security;
using ShopMarket.Domain.ShopEntities;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Pages.Admin.Stores
{
    [PermissionChecker(7)]
    public class EditModel : PageModel
    {
        private readonly IStoreService _storeService;
        private readonly IUserService _userService;

        public EditModel( IStoreService storeService, IUserService userService)
        {
            _storeService = storeService;
            _userService = userService;
        }

        [BindProperty]
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

            var users = _userService.GetAll(new Filter());
            ViewData["UserId"] = new SelectList(users.Users, "Id", "FullName");
            return Page();
        }
        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _storeService.UpdateStore(Store);
            
            return RedirectToPage("./Index");
        }
    }
}

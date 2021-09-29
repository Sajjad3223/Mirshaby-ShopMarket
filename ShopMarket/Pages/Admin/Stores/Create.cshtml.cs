using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopMarket.Core.DTOs;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Security;
using ShopMarket.Domain.ShopEntities;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Pages.Admin.Stores
{
    [PermissionChecker(7)]
    public class CreateModel : PageModel
    {
        private readonly IStoreService _storeService;
        private readonly IUserService _userService;

        public CreateModel(IStoreService storeService, IUserService userService)
        {
            _storeService = storeService;
            _userService = userService;
        }

        public IActionResult OnGet()
        {
            var users = _userService.GetAll(new Filter());
            ViewData["UserId"] = new SelectList(users.Users, "Id", "FullName");
            return Page();
        }

        [BindProperty]
        public Store Store { get; set; }
        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _storeService.InsertStore(Store);

            return RedirectToPage("./Index");
        }
    }
}

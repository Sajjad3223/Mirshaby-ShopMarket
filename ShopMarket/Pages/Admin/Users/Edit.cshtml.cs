using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Security;
using ShopMarket.Core.ViewModels.UserViewModels;

namespace ShopMarket.Pages.Admin.Users
{
    [PermissionChecker(4)]
    public class EditModel : PageModel
    {
        private readonly IUserService _userService;

        public EditModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public UserViewModel UserViewModel { get; set; }

        public async Task<IActionResult> OnGet(int? userId)
        {
            if(userId == null)
                return NotFound();

            UserViewModel = await _userService.GetUser(userId.Value);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            _userService.UpdateUser(UserViewModel);

            return RedirectToPage("Index");
        }
    }
}

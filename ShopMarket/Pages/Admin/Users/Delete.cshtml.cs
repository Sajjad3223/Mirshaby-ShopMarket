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
    public class DeleteModel : PageModel
    {
        private readonly IUserService _userService;

        public DeleteModel(IUserService userService)
        {
            _userService = userService;
        }

        public UserViewModel UserViewModel { get; set; }

        public async Task<IActionResult> OnGet(int? userId)
        {
            if (userId == null)
                return NotFound();

            UserViewModel = await _userService.GetUser(userId.Value);

            return Page();
        }

        public async Task<IActionResult> OnPost(int? userId)
        {
            if (userId == null)
                return NotFound();

            await _userService.DeleteUser(userId.Value);

            return RedirectToPage("Index");
        }
    }
}

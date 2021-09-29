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
    public class CreateModel : PageModel
    {
        private readonly IUserService _userService;

        public CreateModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public UserViewModel UserViewModel { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            await _userService.InsertUser(new RegisterViewModel()
            {
                PhoneNumber = UserViewModel.PhoneNumber,
                Email = UserViewModel.Email,
                FullName = UserViewModel.FullName,
                Password = UserViewModel.Password
            });

            return RedirectToPage("Index");
        }
    }
}

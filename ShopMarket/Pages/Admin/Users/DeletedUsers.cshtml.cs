using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopMarket.Core.DTOs;
using ShopMarket.Core.DTOs.UserDTOs;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Security;
using ShopMarket.Core.ViewModels.UserViewModels;

namespace ShopMarket.Pages.Admin.Users
{
    [PermissionChecker(4)]
    public class DeletedUsersModel : PageModel
    {
        private readonly IUserService _userService;

        public DeletedUsersModel(IUserService userService)
        {
            _userService = userService;
        }

        #region Properties

        public IList<UserViewModel> Users;

        #endregion

        public void OnGet()
        {
            Users = _userService.GetDisabledUsers().ToList();
        }

        public async Task<IActionResult> OnGetReactivate(int id)
        {
            await _userService.ReActivateUser(id);

            return RedirectToPage("DeletedUsers");
        }
    }
}

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
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        #region Properties

        public UsersDto UserDto;

        #endregion

        public void OnGet(int pageId = 1, string search = "", int take = 20)
        {
            UserDto = _userService.GetAll(new Filter()
            {
                PageId = pageId,
                Search = search,
                Take = take
            });
        }
    }
}

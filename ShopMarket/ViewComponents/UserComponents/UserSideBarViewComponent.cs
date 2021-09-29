using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Utilities;

namespace ShopMarket.ViewComponents
{
    [Authorize]
    public class UserSideBarViewComponent : ViewComponent
    {
        private readonly IUserService _userService;

        public UserSideBarViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int userId = (User as ClaimsPrincipal).GetUserId();
            var user = await _userService.GetUser(userId);
            return View(user);
        }
    }
}

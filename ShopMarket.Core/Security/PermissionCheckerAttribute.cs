using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Authorization;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.Interfaces.UserInterfaces;

namespace ShopMarket.Core.Security
{
    public class PermissionCheckerAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private IPermissionService _permissionService;

        private readonly int _permissionId = 0;

        public PermissionCheckerAttribute(int permissionId)
        {
            _permissionId = permissionId;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _permissionService =
                (IPermissionService) context.HttpContext.RequestServices.GetService(typeof(IPermissionService));
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                int userId = context.HttpContext.User.GetUserId();
                if(!_permissionService.DoesUserHasPermission(userId,_permissionId))
                    context.Result = new RedirectResult("/user/account/login?" + context.HttpContext.Request.Path);
            }
            else
            {
                context.Result = new RedirectResult("/user/account/login");
            }
        }
    }
}
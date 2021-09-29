using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Security;
using ShopMarket.Domain.UserEntities.Permissions;

namespace ShopMarket.Pages.Admin.Roles.Permissions
{
    [PermissionChecker(1004)]
    public class IndexModel : PageModel
    {
        private readonly IPermissionService _permissionService;

        public IndexModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public IEnumerable<Permission> Permissions { get; set; }

        public void OnGet()
        {
            Permissions = _permissionService.GetAll();
        }
    }
}

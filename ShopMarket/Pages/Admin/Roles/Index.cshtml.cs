using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Security;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Pages.Admin.Roles
{
    [PermissionChecker(5)]
    public class IndexModel : PageModel
    {
        private readonly IRoleService _roleService;

        public IndexModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public IEnumerable<Role> Roles { get; set; }

        public void OnGet()
        {
            Roles = _roleService.GetAll().ToList();
        }
    }
}

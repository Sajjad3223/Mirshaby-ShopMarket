using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Security;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Pages.Admin.Users
{
    [PermissionChecker(12)]
    public class RolesModel : PageModel
    {
        private readonly IRoleService _roleService;
        private readonly IUserRoleService _userRoleService;

        public RolesModel(IRoleService roleService, IUserRoleService userRoleService)
        {
            _roleService = roleService;
            _userRoleService = userRoleService;
        }

        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<Role> UserRoles { get; set; }

        public IActionResult OnGet(int? userId)
        {
            if (userId == null)
                return NotFound();

            Roles = _roleService.GetAll().ToList();
            UserRoles = _userRoleService.GetRolesByUser(userId.Value).ToList();

            return Page();
        }

        public IActionResult OnPost(int? userId , List<int> roles)
        {
            if (userId == null)
                return NotFound();

            _userRoleService.AddRolesToUser(roles, userId.Value);

            return RedirectToPage("Index");
        }

    }
}

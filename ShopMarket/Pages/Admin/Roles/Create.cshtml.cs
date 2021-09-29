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
    public class CreateModel : PageModel
    {
        private readonly IRoleService _roleService;
        private readonly IPermissionService _permissionService;
        private readonly IRolePermissionService _rolePermissionService;

        public CreateModel(IRoleService roleService, IRolePermissionService rolePermissionService, IPermissionService permissionService)
        {
            _roleService = roleService;
            _rolePermissionService = rolePermissionService;
            _permissionService = permissionService;
        }

        [BindProperty]
        public Role Role { get; set; }

        public void OnGet()
        {
            ViewData["Permissions"] = _permissionService.GetAll();
        }

        public IActionResult OnPost(List<int> SelectedPermissions)
        {
            if (!ModelState.IsValid)
                return Page();

            Role.IsDelete = false;

            int roleId = _roleService.Insert(Role);
            _rolePermissionService.AttachPermissionsToRole(roleId, SelectedPermissions);

            return RedirectToPage("Index");
        }
    }
}

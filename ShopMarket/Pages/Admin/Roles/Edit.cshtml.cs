using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Security;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Pages.Admin.Roles
{
    [PermissionChecker(5)]
    public class EditModel : PageModel
    {
        private readonly IPermissionService _permissionService;
        private readonly IRolePermissionService _rolePermissionService;
        private readonly IRoleService _roleService;

        public EditModel(IPermissionService permissionService, IRolePermissionService rolePermissionService, IRoleService roleService)
        {
            _permissionService = permissionService;
            _rolePermissionService = rolePermissionService;
            _roleService = roleService;
        }

        [BindProperty] 
        public Role Role { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
                return NotFound();

            Role = await _roleService.Get(id.Value);

            ViewData["Permissions"] = _permissionService.GetAll();
            ViewData["SelectedPermissions"] = _rolePermissionService.GetPermissionsByRole(id.Value);

            return Page();
        }

        public IActionResult OnPost(List<int> SelectedPermissions)
        {
            if (!ModelState.IsValid)
                return Page();

            _roleService.Update(Role);

            _rolePermissionService.UpdatePermissionsOfRole(Role.RoleId, SelectedPermissions);

            return RedirectToPage("Index");
        }
    }
}

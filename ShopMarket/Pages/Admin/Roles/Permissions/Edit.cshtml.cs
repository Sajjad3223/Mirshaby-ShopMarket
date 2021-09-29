using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Security;
using ShopMarket.Domain.UserEntities.Permissions;

namespace ShopMarket.Pages.Admin.Roles.Permissions
{
    [PermissionChecker(1004)]
    public class EditModel : PageModel
    {
        private readonly IPermissionService _permissionService;

        public EditModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [BindProperty]
        public Permission Permission { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if(id == null)
                return NotFound();
            Permission = await _permissionService.GetPermission(id.Value);
            ViewData["Permissions"] = new SelectList(_permissionService.GetAll(), "PermissionId", "PermissionTitle",Permission.ParentID);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _permissionService.UpdatePermission(Permission);

            return RedirectToPage("Index");
        }
    }
}

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
    public class CreateModel : PageModel
    {
        private readonly IPermissionService _permissionService;

        public CreateModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [BindProperty]
        public Permission Permission { get; set; }

        public void OnGet()
        {
            ViewData["Permissions"] = new SelectList(_permissionService.GetAll(), "PermissionId", "PermissionTitle");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _permissionService.InsertPermission(Permission);

            return RedirectToPage("Index");
        }
    }
}

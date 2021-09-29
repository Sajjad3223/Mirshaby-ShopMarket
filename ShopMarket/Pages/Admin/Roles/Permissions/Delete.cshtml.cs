using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Security;

namespace ShopMarket.Pages.Admin.Roles.Permissions
{
    [PermissionChecker(1004)]
    public class DeleteModel : PageModel
    {
        private readonly IPermissionService _permissionService;

        public DeleteModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [BindProperty]
        public int Id { get; set; }

        public string PermissionTitle { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
                return NotFound();

            Id = id.Value;
            PermissionTitle = (await _permissionService.GetPermission(id.Value)).PermissionTitle;

            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            if (Id == default)
                return NotFound();

            await _permissionService.DeletePermission(Id);

            return RedirectToPage("Index");
        }
    }
}

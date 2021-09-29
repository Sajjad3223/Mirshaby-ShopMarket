using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Security;
using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Pages.Admin.Stores
{
    [PermissionChecker(7)]
    public class DeletedStoresModel : PageModel
    {
        private readonly IStoreService _storeService;

        public DeletedStoresModel(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public IList<Store> Stores { get; set; }

        public void OnGet()
        {
            Stores = _storeService.GetDeletedStores().ToList();
        }

        public async Task<IActionResult> OnGetReactivate(int id)
        {
            await _storeService.ReActivateStore(id);

            return RedirectToPage("DeletedStores");
        }
    }
}

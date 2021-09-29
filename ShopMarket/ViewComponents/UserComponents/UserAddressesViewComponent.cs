using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopMarket.Core.Interfaces.UserInterfaces;

namespace ShopMarket.ViewComponents
{
    public class UserAddressesViewComponent : ViewComponent
    {
        private readonly IUserAddressService _addressService;

        public UserAddressesViewComponent(IUserAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int userId)
        {
            var addresses = _addressService.GetUserAddresses(userId).ToList();

            return View(addresses);
        }
    }
}
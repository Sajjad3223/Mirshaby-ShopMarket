using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopMarket.Core.Interfaces.ShopInterfaces;

namespace ShopMarket.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly IShopCategoryService _categoryService;

        public CategoriesViewComponent(IShopCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = _categoryService.GetAll().ToList();
            return View(categories);
        }

    }
}
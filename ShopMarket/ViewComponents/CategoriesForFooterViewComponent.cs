using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopMarket.Core.Interfaces.ShopInterfaces;

namespace ShopMarket.ViewComponents
{
    public class CategoriesForFooterViewComponent : ViewComponent
    {
        private readonly IShopCategoryService _categoryService;

        public CategoriesForFooterViewComponent(IShopCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = _categoryService.GetAll().ToList();
            categories = categories.Where(c => c.ParentId == null).ToList();

            return View(categories);
        }
    }
}
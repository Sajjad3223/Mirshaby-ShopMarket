using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces;

namespace ShopMarket.ViewComponents.IndexComponents
{
    public class MainPageSliderViewComponent : ViewComponent
    {
        private readonly ISliderService _sliderService;

        public MainPageSliderViewComponent(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var slides = _sliderService.GetAllSlides().ToList();
            return View(slides);
        }
    }
}
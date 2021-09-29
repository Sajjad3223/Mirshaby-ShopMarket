using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Security;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Pages.Admin
{
    [PermissionChecker(8)]
    public class SliderModel : PageModel
    {
        private readonly ISliderService _sliderService;

        public SliderModel(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public IList<Slide> Slides { get; set; }

        public void OnGet()
        {
            Slides = _sliderService.GetAllSlides().ToList();
        }

        public IActionResult OnPost(List<IFormFile> slide_Images, List<string> slide_texts, List<string> slide_links)
        {
            var result = _sliderService.UpdateSlides(
                new Tuple<List<IFormFile>, List<string>, List<string>>(slide_Images, slide_texts, slide_links));

            if (result.Status != OperationResultStatus.Success)
                return Page();

            return RedirectToPage("Index");
        }
    }
}

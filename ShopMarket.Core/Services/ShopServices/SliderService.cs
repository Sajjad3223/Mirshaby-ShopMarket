using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Core.Services.FileManager;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.Interfaces.ShopInterfaces;
using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Core.Services.ShopServices
{
    public class SliderService : ISliderService
    {
        private readonly IFileManager _fileManager;
        private readonly ISliderRepository _sliderRepository;

        public SliderService(IFileManager fileManager, ISliderRepository sliderRepository)
        {
            _fileManager = fileManager;
            _sliderRepository = sliderRepository;
        }


        public IQueryable<Slide> GetAllSlides()
        {
            return _sliderRepository.GetAll();
        }

        public OperationResult InsertSlides(Tuple<List<IFormFile>, List<string>, List<string>> slides)
        {
            try
            {
                for (int i=0; i < slides.Item1.Count; i++)
                {
                    string imageName = _fileManager.SaveFileTo(slides.Item1[i], Directories.SliderImage);
                    _sliderRepository.InsertSlide(new Slide()
                    {
                        SlideImage = imageName,
                        SlideContent = slides.Item2[i],
                        SlideLink = slides.Item3[i]
                    });
                }
                _sliderRepository.Save();
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult UpdateSlides(Tuple<List<IFormFile>, List<string>, List<string>> slides)
        {
            DeleteSlides();
            return InsertSlides(slides);
        }

        public OperationResult DeleteSlides()
        {
            try
            {
                var slides = GetAllSlides().ToList();

                if (slides.Any())
                {
                    foreach (var slide in slides)
                    {
                        _fileManager.DeleteFile(Directories.SliderImage, slide.SlideImage);
                        _sliderRepository.DeleteSlide(slide);
                    }
                }

                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }
    }
}
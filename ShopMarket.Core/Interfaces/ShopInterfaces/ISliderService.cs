using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Core.Interfaces.ShopInterfaces
{
    public interface ISliderService
    {
        IQueryable<Slide> GetAllSlides();

        OperationResult InsertSlides(Tuple<List<IFormFile>, List<string>, List<string>> slides);

        OperationResult UpdateSlides(Tuple<List<IFormFile>, List<string>, List<string>> slides);

        OperationResult DeleteSlides();

    }
}
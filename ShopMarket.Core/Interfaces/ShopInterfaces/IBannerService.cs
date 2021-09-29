using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Core.Interfaces.ShopInterfaces
{
    public interface IBannerService
    {
        IQueryable<Banner> GetAllBanners();

        OperationResult InsertBanners(Tuple<List<IFormFile>, List<string>> banners);

        OperationResult UpdateBanners(Tuple<List<IFormFile>, List<string>> banners);

        OperationResult DeleteBanners();
    }
}
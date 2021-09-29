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
    public class BannerService : IBannerService
    {
        private readonly IFileManager _fileManager;
        private readonly IBannerRepository _bannerRepository;

        public BannerService(IBannerRepository bannerRepository, IFileManager fileManager)
        {
            _bannerRepository = bannerRepository;
            _fileManager = fileManager;
        }
        public IQueryable<Banner> GetAllBanners()
        {
            return _bannerRepository.GetAllBanners();
        }

        public OperationResult InsertBanners(Tuple<List<IFormFile>, List<string>> banners)
        {
            try
            {
                for (int i = 0; i < banners.Item1.Count; i++)
                {
                    string imageName = _fileManager.SaveFileTo(banners.Item1[i], Directories.BannerImage);
                    _bannerRepository.InsertBanner(new Banner()
                    {
                        BannerImage = imageName,
                        BannerLink = banners.Item2[i]
                    });
                }
                _bannerRepository.Save();
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult UpdateBanners(Tuple<List<IFormFile>, List<string>> banners)
        {
            DeleteBanners();
            return InsertBanners(banners);
        }

        public OperationResult DeleteBanners()
        {
            try
            {
                var banners = GetAllBanners().ToList();

                if (banners.Any())
                {
                    foreach (var banner in banners)
                    {
                        _fileManager.DeleteFile(Directories.BannerImage, banner.BannerImage);
                        _bannerRepository.DeleteBanner(banner);
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
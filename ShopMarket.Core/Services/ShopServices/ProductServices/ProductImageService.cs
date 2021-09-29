using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.DTOs.ProductDto;
using ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Core.Services.ShopServices.ProductServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRepository _productImageRepository;

        public ProductImageService(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public OperationResult DeleteImage(ProductImage image)
        {
            try
            {
                if (image == null)
                    return OperationResult.NotFound();
                _productImageRepository.DeleteImage(image);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult DeleteImage(string imageId)
        {
            try
            {
                if (imageId == null)
                    return OperationResult.NotFound();
                _productImageRepository.DeleteImage(imageId);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }
        
        public async Task<ProductDto> FillProductViewModels(ProductDto productDto)
        {
            foreach (var product in productDto.Products)
            {
                product.MainImage = (await GetMainImage(product.ProductId)).ImageName;
            }

            return productDto;
        }

        public IQueryable<ProductImage> GetAll(int productId)
        {
            return _productImageRepository.GetAll(productId);
        }

        public Task<ProductImage> GetImage(string imageId)
        {
            return _productImageRepository.GetImage(imageId);
        }

        public Task<ProductImage> GetMainImage(int productId)
        {
            return _productImageRepository.GetMainImage(productId);
        }

        public OperationResult InsertImage(ProductImage image)
        {
            try
            {
                if (image == null)
                    return OperationResult.NotFound();
                _productImageRepository.InsertImage(image);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult InsertImages(List<ProductImage> images, int productId)
        {
            try
            {
                if (images == null)
                    return OperationResult.NotFound();
                foreach (var image in images)
                {
                    image.ProductId = productId;
                    _productImageRepository.InsertImage(image);
                }

                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public void Save()
        {
            _productImageRepository.Save();
        }

        public OperationResult UpdateImage(ProductImage image)
        {
            try
            {
                if (image == null)
                    return OperationResult.NotFound();
                _productImageRepository.UpdateImage(image);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }
    }
}
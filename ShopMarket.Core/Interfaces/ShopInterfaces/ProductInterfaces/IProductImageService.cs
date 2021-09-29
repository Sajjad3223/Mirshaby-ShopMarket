using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.DTOs.ProductDto;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces
{
    public interface IProductImageService
    {
        IQueryable<ProductImage> GetAll(int productId);

        Task<ProductImage> GetMainImage(int productId);

        Task<ProductDto> FillProductViewModels(ProductDto productDto);

        Task<ProductImage> GetImage(string imageId);

        OperationResult InsertImage(ProductImage image);

        OperationResult InsertImages(List<ProductImage> images,int productId);

        OperationResult UpdateImage(ProductImage image);

        OperationResult DeleteImage(ProductImage image);

        OperationResult DeleteImage(string imageId);

        void Save();
    }
}
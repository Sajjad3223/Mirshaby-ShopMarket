using System;
using System.Collections.Generic;
using System.Linq;
using ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Domain.ShopEntities;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Core.Services.ShopServices.ProductServices
{
    public class AvailableProductSizeService : IAvailableProductSizeService
    {
        private readonly IAvailableProductSizeRepository _sizeRepository;

        public AvailableProductSizeService(IAvailableProductSizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        public OperationResult DeleteSize(AvailableProductSize size)
        {
            try
            {
                if (size == null)
                    return OperationResult.NotFound();
                _sizeRepository.DeleteSize(size);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult DeleteSize(int id)
        {
            try
            {
                if (id == null)
                    return OperationResult.NotFound();
                _sizeRepository.DeleteSize(id);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public IQueryable<AvailableProductSize> GetAllAvailableSizes(int productId)
        {
            return _sizeRepository.GetAllAvailableSizes(productId);
        }

        public OperationResult InsertSize(AvailableProductSize size)
        {
            try
            {
                if (size == null)
                    return OperationResult.NotFound();
                _sizeRepository.InsertSize(size);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public void InsertSizesToProduct(List<string> sizes, int productId)
        {
            List<ESize> convertedSizes = sizes.Select(Enum.Parse<ESize>).ToList();
            foreach (var size in convertedSizes)
            {
                InsertSize(new AvailableProductSize()
                {
                    ProductId = productId,
                    Size = size
                });
            }
            _sizeRepository.Save();
        }
        

        public void UpdateSizes(List<string> availableSizes, int productId)
        {
            var sizes = GetAllAvailableSizes(productId).ToList();

            sizes.ForEach(s=>DeleteSize(s));

            InsertSizesToProduct(availableSizes,productId);
        }
    }
}
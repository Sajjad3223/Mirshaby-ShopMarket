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
    public class AvailableProductColorService : IAvailableProductColorService
    {
        private readonly IAvailableProductColorRepository _colorRepository;

        public AvailableProductColorService(IAvailableProductColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public OperationResult DeleteColor(AvailableProductColor color)
        {
            try
            {
                if (color == null)
                    return OperationResult.NotFound();
                _colorRepository.DeleteColor(color);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult DeleteColor(int id)
        {
            try
            {
                if (id == null)
                    return OperationResult.NotFound();
                _colorRepository.DeleteColor(id);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public IQueryable<AvailableProductColor> GetAllAvailableColors(int productId)
        {
            return _colorRepository.GetAllAvailableColors(productId);
        }

        public OperationResult InsertColor(AvailableProductColor color)
        {
            try
            {
                if (color == null)
                    return OperationResult.NotFound();
                _colorRepository.InsertColor(color);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public void InsertColorsToProduct(List<string> availableColors, int productId)
        {
            List<EColor> convertedColors = availableColors.Select(Enum.Parse<EColor>).ToList();

            foreach (var color in convertedColors)
            {
                InsertColor(new AvailableProductColor()
                {
                    Color = color,
                    ProductId = productId
                });
            }
            _colorRepository.Save();
        }
        
        public void UpdateColors(List<string> availableColors, int productId)
        {
            var colors = GetAllAvailableColors(productId).ToList();

            colors.ForEach(c=>DeleteColor(c));

            InsertColorsToProduct(availableColors, productId);
        }
    }
}
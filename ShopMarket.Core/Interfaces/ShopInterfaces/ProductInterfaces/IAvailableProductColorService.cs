using System.Collections.Generic;
using System.Linq;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.ShopEntities;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces
{
    public interface IAvailableProductColorService
    {
        IQueryable<AvailableProductColor> GetAllAvailableColors(int productId);

        OperationResult InsertColor(AvailableProductColor color);

        OperationResult DeleteColor(AvailableProductColor color);

        OperationResult DeleteColor(int id);

        void InsertColorsToProduct(List<string> availableColors, int productId);
        void UpdateColors(List<string> availableColors, int productId);
    }
}
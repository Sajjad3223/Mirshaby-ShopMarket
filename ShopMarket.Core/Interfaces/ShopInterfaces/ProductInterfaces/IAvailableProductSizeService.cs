using System.Collections.Generic;
using System.Linq;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.ShopEntities;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces
{
    public interface IAvailableProductSizeService
    {
        IQueryable<AvailableProductSize> GetAllAvailableSizes(int productId);

        OperationResult InsertSize(AvailableProductSize size);

        OperationResult DeleteSize(AvailableProductSize size);

        OperationResult DeleteSize(int id);

        void InsertSizesToProduct(List<string> sizes, int productId);
        void UpdateSizes(List<string> availableSizes, int productId);
    }
}
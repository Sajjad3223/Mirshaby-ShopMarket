using System;
using System.Collections.Generic;
using System.Linq;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces
{
    public interface IProductDetailService
    {
        IQueryable<ProductDetail> GetProductDetails(int productId);

        OperationResult InsertDetail(ProductDetail detail);

        OperationResult DeleteDetail(ProductDetail detail);

        OperationResult DeleteDetail(int id);

        void InsertDetailsToProduct(Tuple<List<string>, List<string>> details, int productId);
        void UpdateDetails(Tuple<List<string>, List<string>> detailsTuple, int productId);
    }
}
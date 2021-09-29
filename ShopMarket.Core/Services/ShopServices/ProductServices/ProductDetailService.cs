using System;
using System.Collections.Generic;
using System.Linq;
using ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Core.Services.ShopServices.ProductServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IProductDetailRepository _productDetailRepository;

        public ProductDetailService(IProductDetailRepository productDetailRepository)
        {
            _productDetailRepository = productDetailRepository;
        }

        public OperationResult DeleteDetail(ProductDetail detail)
        {
            try
            {
                if (detail == null)
                    return OperationResult.NotFound();
                _productDetailRepository.DeleteDetail(detail);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult DeleteDetail(int id)
        {
            try
            {
                if (id == null)
                    return OperationResult.NotFound();
                _productDetailRepository.DeleteDetail(id);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public IQueryable<ProductDetail> GetProductDetails(int productId)
        {
            return _productDetailRepository.GetProductDetails(productId);
        }

        public OperationResult InsertDetail(ProductDetail detail)
        {
            try
            {
                if (detail == null)
                    return OperationResult.NotFound();
                _productDetailRepository.InsertDetail(detail);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public void InsertDetailsToProduct(Tuple<List<string>, List<string>> details, int productId)
        {
            for (int i = 0; i < details.Item1.Count; i++)
            {
                InsertDetail(new ProductDetail()
                {
                    Key = details.Item1[i] ?? "",
                    Value = details.Item2[i] ?? "",
                    ProductId = productId
                });
            }
            _productDetailRepository.Save();
        }

        public void UpdateDetails(Tuple<List<string>, List<string>> detailsTuple, int productId)
        {
            var details = GetProductDetails(productId).ToList();

            details.ForEach(d=>DeleteDetail(d));

            InsertDetailsToProduct(detailsTuple,productId);

        }
    }
}
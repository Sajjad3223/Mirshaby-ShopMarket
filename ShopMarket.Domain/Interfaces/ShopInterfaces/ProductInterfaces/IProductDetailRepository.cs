using System.Linq;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Domain.Interfaces.ShopInterfaces.ProductInterfaces
{
    public interface IProductDetailRepository
    {
        IQueryable<ProductDetail> GetProductDetails(int productId);

        void InsertDetail(ProductDetail detail);

        void UpdateDetail(ProductDetail detail);

        void DeleteDetail(ProductDetail detail);

        void DeleteDetail(int id);

        void Save();
    }
}
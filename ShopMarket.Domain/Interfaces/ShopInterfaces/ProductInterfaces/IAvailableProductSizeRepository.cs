using System.Linq;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Domain.Interfaces.ShopInterfaces.ProductInterfaces
{
    public interface IAvailableProductSizeRepository
    {
        IQueryable<AvailableProductSize> GetAllAvailableSizes(int productId);

        void InsertSize(AvailableProductSize size);
                   
        void UpdateSize(AvailableProductSize size);
                   
        void DeleteSize(AvailableProductSize size);
                   
        void DeleteSize(int id);

        void Save();
    }
}
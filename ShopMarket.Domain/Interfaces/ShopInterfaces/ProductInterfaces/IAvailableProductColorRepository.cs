using System.Linq;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Domain.Interfaces.ShopInterfaces.ProductInterfaces
{
    public interface IAvailableProductColorRepository
    {
        IQueryable<AvailableProductColor> GetAllAvailableColors(int productId);

        void InsertColor(AvailableProductColor color);
                   
        void UpdateColor(AvailableProductColor color);
                   
        void DeleteColor(AvailableProductColor color);
                   
        void DeleteColor(int id);

        void Save();
    }
}
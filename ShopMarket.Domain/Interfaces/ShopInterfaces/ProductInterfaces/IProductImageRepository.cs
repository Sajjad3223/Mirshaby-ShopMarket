using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Domain.Interfaces.ShopInterfaces.ProductInterfaces
{
    public interface IProductImageRepository
    {
        IQueryable<ProductImage> GetAll(int productId);

        Task<ProductImage> GetMainImage(int productId);

        Task<ProductImage> GetImage(string imageId);

        void InsertImage(ProductImage image);

        void UpdateImage(ProductImage image);

        void DeleteImage(ProductImage image);

        void DeleteImage(string imageId);

        void Save();
    }
}
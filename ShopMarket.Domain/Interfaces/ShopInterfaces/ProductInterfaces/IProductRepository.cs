using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Domain.Interfaces.ShopInterfaces.ProductInterfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAll();

        IQueryable<Product> GetProductsByCategory(int categoryId);

        IQueryable<Product> GetProductsByStore(int storeId);

        Task<Product> GetProduct(int id);

        Task<Product> GetProductByShortLink(string shortLink);

        int InsertProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(Product product);

        void DeleteProduct(int id);

        void Save();
        IQueryable<Product> GetShowInSliderProducts();
        IQueryable<Product> GetMostVisitedProducts();

        bool DoesLinkExists(string link);

        IQueryable<Product> GetSpecialProducts();
        IQueryable<Product> GetDeletedProducts();
        void ReActivateProduct(Product product);
    }
}
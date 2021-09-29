using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Domain.Interfaces.ShopInterfaces
{
    public interface IShopCategoryRepository
    {
        IQueryable<ShopCategory> GetAll();
        IQueryable<ShopCategory> GetCategoriesByParent(int parentId);

        Task<ShopCategory> GetCategory(int id);
        Task<ShopCategory> GetCategory(string slug);

        Task<bool> DoesSlugExist(string slug);

        void InsertCategory(ShopCategory category);

        void UpdateCategory(ShopCategory category);

        void DeleteCategory(ShopCategory category);
        
        void DeleteCategory(int id);
    }
}
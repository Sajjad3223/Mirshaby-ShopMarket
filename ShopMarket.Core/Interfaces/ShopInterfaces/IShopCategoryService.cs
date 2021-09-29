using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;
using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Core.Interfaces.ShopInterfaces
{
    public interface IShopCategoryService
    {
        IQueryable<ShopCategoryViewModel> GetAll();
        IQueryable<ShopCategoryViewModel> GetSubCategories(int parentId);

        Task<ShopCategoryViewModel> GetCategory(int id);
        Task<ShopCategoryViewModel> GetCategory(string slug);

        Task<bool> DoesSlugExist(string slug);

        Task<OperationResult> InsertCategory(ShopCategoryViewModel category);

        Task<OperationResult> UpdateCategory(ShopCategoryViewModel category);

        OperationResult DeleteCategory(ShopCategoryViewModel category);

        Task<OperationResult> DeleteCategory(int id);
    }
}
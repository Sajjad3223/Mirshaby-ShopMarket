using System;
using System.Collections.Generic;
using ShopMarket.Core.Interfaces.ShopInterfaces;
using ShopMarket.Domain.ShopEntities;
using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Domain.Interfaces.ShopInterfaces;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.Utilities.Mappers;
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;

namespace ShopMarket.Core.Services.ShopServices
{
    public class ShopCategoryService : IShopCategoryService
    {
        private readonly IShopCategoryRepository _shopCategoryRepository;

        public ShopCategoryService(IShopCategoryRepository shopCategoryRepository)
        {
            _shopCategoryRepository = shopCategoryRepository;
        }

        public OperationResult DeleteCategory(ShopCategoryViewModel category)
        {
            try
            {
                _shopCategoryRepository.DeleteCategory(category.MapToShopCategory());
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public async Task<OperationResult> DeleteCategory(int id)
        {
            var category = await GetCategory(id);
            return DeleteCategory(category);
        }
        
        public Task<bool> DoesSlugExist(string slug)
        {
            return _shopCategoryRepository.DoesSlugExist(slug);
        }

        public IQueryable<ShopCategoryViewModel> GetAll()
        {
            return _shopCategoryRepository.GetAll().Select(c=>c.MapToViewModel());
        }

        public async Task<ShopCategoryViewModel> GetCategory(int id)
        {
            var category = await _shopCategoryRepository.GetCategory(id);
            if (category == null)
                return null;
            return category.MapToViewModel();
        }

        public async Task<ShopCategoryViewModel> GetCategory(string slug)
        {
            return (await _shopCategoryRepository.GetCategory(slug)).MapToViewModel();
        }

        public IQueryable<ShopCategoryViewModel> GetSubCategories(int parentId)
        {
            return _shopCategoryRepository.GetCategoriesByParent(parentId).Select(c=>c.MapToViewModel());
        }

        public async Task<OperationResult> InsertCategory(ShopCategoryViewModel category)
        {
            try
            {
                if(await DoesSlugExist(category.Slug))
                    return OperationResult.Error("اسلاگ موجود است");
                

                _shopCategoryRepository.InsertCategory(category.MapToShopCategory());
                return OperationResult.Success();
            }
            catch 
            {
                return OperationResult.Error();
            }
        }

        public async Task<OperationResult> UpdateCategory(ShopCategoryViewModel category)
        {
            try
            {
                if((await GetCategory(category.CategoryId)).Slug != category.Slug)
                    if (await DoesSlugExist(category.Slug))
                        return OperationResult.Error("اسلاگ موجود است");
                _shopCategoryRepository.UpdateCategory(category.MapToShopCategory());
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }
    }
}
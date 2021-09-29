using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.DTOs;
using ShopMarket.Core.DTOs.ProductDto;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;
using ShopMarket.Domain.ShopEntities.OrderEntities;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces
{
    public interface IProductService
    {
        ProductDto GetAll(ProductFilter filter);

        ProductDto GetProductsByCategory(int categoryId, ProductFilter filter);

        ProductDto GetProductsByStore(int storeId, ProductFilter filter);

        IQueryable<ProductViewModel> GetShowInSliderProducts();

        IQueryable<ProductViewModel> GetDeletedProducts();

        Task<ProductViewModel> GetProduct(int id);

        Task<ProductViewModel> GetProductByShortLink(string shortLink);

        int InsertProduct(ProductViewModel product);

        bool DoesLinkExists(string link);

        OperationResult UpdateProduct(ProductViewModel product);

        OperationResult DeleteProduct(ProductViewModel product);

        Task<OperationResult> DeleteProduct(int id);

        Task<OperationResult> AddVisitToProduct(int productId);

        OperationResult DecreaseProductsCount(List<OrderItem> items);

        IQueryable<ProductViewModel> GetMostVisitedProducts();

        IQueryable<ProductViewModel> GetSpecialProducts();

        Task<OperationResult> ReActivateProduct(int id);
    }
}
using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.DTOs.UserDTOs;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;
using ShopMarket.Core.ViewModels.UserViewModels;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Core.Interfaces.UserInterfaces
{
    public interface ILikedProductService
    {
        IQueryable<LikedProductViewModel> GetUserLikedProducts(int userId);

        OperationResult InsertLikedProduct(LikedProductViewModel like);

        OperationResult DeleteLikedProduct(LikedProductViewModel like);

        OperationResult DeleteLikedProduct(int id);

        bool HasProductInLikes(int userId, int productId);
        void DeleteLikedProductByProductId(int userId, int productId);
    }
}
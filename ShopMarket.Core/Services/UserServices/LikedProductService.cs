using System.Linq;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.Utilities.Mappers;
using ShopMarket.Core.ViewModels.ShopViewModels.ProductViewModels;
using ShopMarket.Domain.Interfaces.UserInterfaces;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Core.Services.UserServices
{
    public class LikedProductService : ILikedProductService
    {
        private readonly ILikedProductRepository _likedProductRepository;

        public LikedProductService(ILikedProductRepository likedProductRepository)
        {
            _likedProductRepository = likedProductRepository;
        }

        public OperationResult DeleteLikedProduct(LikedProductViewModel like)
        {
            try
            {
                if (like == null)
                    return OperationResult.NotFound();
                _likedProductRepository.DeleteLikedProduct(new LikedProduct()
                {
                    UserId = like.UserId,
                    LikedProductId = like.LikedId,
                    ProductId = like.ProductId
                });
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult DeleteLikedProduct(int id)
        {
            try
            {
                if (id == null)
                    return OperationResult.NotFound();
                _likedProductRepository.DeleteLikedProduct(id);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public bool HasProductInLikes(int userId, int productId)
        {
            return _likedProductRepository.HasProductInLikes(userId, productId);
        }

        public void DeleteLikedProductByProductId(int userId, int productId)
        {
            _likedProductRepository.DeleteLikedProductByProductId(userId, productId);
        }

        public IQueryable<LikedProductViewModel> GetUserLikedProducts(int userId)
        {
            return _likedProductRepository.GetUserLikedProducts(userId).Select(l=>l.MapToViewModel());
        }

        public OperationResult InsertLikedProduct(LikedProductViewModel like)
        {
            try
            {
                if (like == null)
                    return OperationResult.NotFound();
                _likedProductRepository.InsertLikedProduct(new LikedProduct()
                {
                    UserId = like.UserId,
                    ProductId =like.ProductId
                });
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }
        
    }
}
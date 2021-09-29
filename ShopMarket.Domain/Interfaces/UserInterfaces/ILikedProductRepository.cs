using System.Linq;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Domain.Interfaces.UserInterfaces
{
    public interface ILikedProductRepository
    {
        IQueryable<LikedProduct> GetUserLikedProducts(int userId);

        void InsertLikedProduct(LikedProduct like);

        void DeleteLikedProduct(LikedProduct like);

        void DeleteLikedProduct(int id);

        void Save();
        bool HasProductInLikes(int userId, int productId);
        void DeleteLikedProductByProductId(int userId, int productId);
    }
}
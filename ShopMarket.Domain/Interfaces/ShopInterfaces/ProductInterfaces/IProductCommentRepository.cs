using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Domain.Interfaces.ShopInterfaces.ProductInterfaces
{
    public interface IProductCommentRepository
    {
        IQueryable<ProductComment> GetProductCommentsByProduct(int productId);

        IQueryable<ProductComment> GetProductCommentsByUser(int userId);

        Task<ProductComment> GetProductComment(int commentId);

        void InsertComment(ProductComment comment);
                   
        void UpdateComment(ProductComment comment);
                   
        void DeleteComment(ProductComment comment);
                   
        void DeleteComment(int id);

        void Save();
    }
}
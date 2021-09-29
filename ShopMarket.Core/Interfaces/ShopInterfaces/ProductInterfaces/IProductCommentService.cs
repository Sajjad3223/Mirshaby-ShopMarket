using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.ViewModels.ShopViewModels;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces
{
    public interface IProductCommentService
    {
        IQueryable<ProductCommentViewModel> GetProductCommentsByProduct(int productId);

        IQueryable<ProductCommentViewModel> GetProductCommentsByUser(int userId);

        Task<ProductCommentViewModel> GetProductComment(int commentId);

        OperationResult InsertComment(ProductCommentViewModel comment);

        OperationResult UpdateComment(ProductCommentViewModel comment);

        OperationResult DeleteComment(ProductCommentViewModel comment);

        OperationResult DeleteComment(int id);
    }
}
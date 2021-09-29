using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.Utilities.Mappers;
using ShopMarket.Core.ViewModels.ShopViewModels;
using ShopMarket.Domain.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Domain.ShopEntities.ProductEntities;

namespace ShopMarket.Core.Services.ShopServices.ProductServices
{
    public class ProductCommentService : IProductCommentService
    {
        private readonly IProductCommentRepository _productCommentRepository;

        public ProductCommentService(IProductCommentRepository productCommentRepository)
        {
            _productCommentRepository = productCommentRepository;
        }

        public OperationResult DeleteComment(ProductCommentViewModel comment)
        {
            try
            {
                if (comment == null)
                    return OperationResult.NotFound();
                _productCommentRepository.DeleteComment(comment.MapToProductComment());
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult DeleteComment(int id)
        {
            try
            {
                if (id == null)
                    return OperationResult.NotFound();
                _productCommentRepository.DeleteComment(id);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public async Task<ProductCommentViewModel> GetProductComment(int commentId)
        {
            var comment = await _productCommentRepository.GetProductComment(commentId);
            if(comment != null)
                return comment.MapToViewModel();
            return null;
        }

        public IQueryable<ProductCommentViewModel> GetProductCommentsByProduct(int productId)
        {
            return _productCommentRepository.GetProductCommentsByProduct(productId).Select(c => c.MapToViewModel());
        }

        public IQueryable<ProductCommentViewModel> GetProductCommentsByUser(int userId)
        {
            return _productCommentRepository.GetProductCommentsByUser(userId).Select(c=>c.MapToViewModel());
        }

        public OperationResult InsertComment(ProductCommentViewModel comment)
        {
            try
            {
                if (comment == null)
                    return OperationResult.NotFound();
                _productCommentRepository.InsertComment(comment.MapToProductComment());
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult UpdateComment(ProductCommentViewModel comment)
        {
            try
            {
                if (comment == null)
                    return OperationResult.NotFound();
                _productCommentRepository.UpdateComment(comment.MapToProductComment());
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }
    }
}
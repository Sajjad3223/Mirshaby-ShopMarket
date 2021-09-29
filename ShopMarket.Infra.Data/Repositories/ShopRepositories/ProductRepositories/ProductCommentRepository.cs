using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Domain.Interfaces.ShopInterfaces.ProductInterfaces;
using ShopMarket.Domain.ShopEntities.ProductEntities;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Infra.Data.Repositories.ShopRepositories.ProductRepositories
{
    public class ProductCommentRepository : IProductCommentRepository
    {
        private readonly ShopMarketDbContext _context;

        public ProductCommentRepository(ShopMarketDbContext context)
        {
            _context = context;
        }

        public void DeleteComment(ProductComment comment)
        {
            comment.IsDeleted = true;
            UpdateComment(comment);
        }

        public async void DeleteComment(int id)
        {
            var comment = await GetProductComment(id);
            DeleteComment(comment);
        }

        public Task<ProductComment> GetProductComment(int commentId)
        {
            return _context.ProductComments.AsNoTracking().FirstOrDefaultAsync(c => c.Id == commentId);
        }

        public IQueryable<ProductComment> GetProductCommentsByProduct(int productId)
        {
            return _context.ProductComments.Where(c => c.ProductId == productId);
        }

        public IQueryable<ProductComment> GetProductCommentsByUser(int userId)
        {
            return _context.ProductComments.Where(c => c.UserId == userId);
        }

        public void InsertComment(ProductComment comment)
        {
            _context.Add(comment);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateComment(ProductComment comment)
        {
            _context.Update(comment);
            Save();
        }
    }
}
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Domain.Interfaces.UserInterfaces;
using ShopMarket.Domain.UserEntities;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Infra.Data.Repositories.UserRepositories
{
    public class LikedProductRepository : ILikedProductRepository
    {
        private readonly ShopMarketDbContext _context;

        public LikedProductRepository(ShopMarketDbContext context)
        {
            _context = context;
        }

        public IQueryable<LikedProduct> GetUserLikedProducts(int userId)
        {
            return _context.LikedProducts.Where(l => l.UserId == userId).Include(l=>l.Product);
        }

        public void InsertLikedProduct(LikedProduct like)
        {
            _context.Add(like);
            Save();
        }

        public void DeleteLikedProduct(LikedProduct like)
        {
            _context.Remove(like);
            Save();
        }

        public void DeleteLikedProduct(int id)
        {
            var like = _context.LikedProducts.AsNoTracking().FirstOrDefault(v => v.LikedProductId == id);
            DeleteLikedProduct(like);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool HasProductInLikes(int userId, int productId)
        {
            return _context.LikedProducts.Any(l => l.UserId == userId && l.ProductId == productId);
        }

        public void DeleteLikedProductByProductId(int userId, int productId)
        {
            var like = _context.LikedProducts.FirstOrDefault(l => l.UserId == userId && l.ProductId == productId);
            DeleteLikedProduct(like);
        }
    }
}
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopMarket.Domain.Interfaces.UserInterfaces;
using ShopMarket.Domain.UserEntities;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Infra.Data.Repositories.UserRepositories
{
    public class RecentVisitRepository : IRecentVisitRepository
    {
        private readonly ShopMarketDbContext _context;

        public RecentVisitRepository(ShopMarketDbContext context)
        {
            _context = context;
        }

        public void DeleteRecentVisit(int id)
        {
            var visit = _context.RecentVisits.AsNoTracking().FirstOrDefault(v => v.RecentVisitId == id);
            DeleteRecentVisit(visit);
        }

        public void DeleteRecentVisit(RecentVisit visit)
        {
            _context.Remove(visit);
            Save();
        }

        public IQueryable<RecentVisit> GetUserRecentVisits(int userId)
        {
            return _context.RecentVisits.Where(v => v.UserId == userId).Include(r=>r.Product);
        }

        public void InsertRecentVisit(RecentVisit visit)
        {
            _context.Add(visit);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
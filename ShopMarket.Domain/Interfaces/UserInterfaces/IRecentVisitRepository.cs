using System.Linq;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Domain.Interfaces.UserInterfaces
{
    public interface IRecentVisitRepository
    {
        IQueryable<RecentVisit> GetUserRecentVisits(int userId);

        void InsertRecentVisit(RecentVisit visit);

        void DeleteRecentVisit(RecentVisit visit);

        void DeleteRecentVisit(int id);

        void Save();
    }
}
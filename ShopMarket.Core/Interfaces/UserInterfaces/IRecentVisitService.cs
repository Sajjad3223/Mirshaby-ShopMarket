using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.DTOs.UserDTOs;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.ViewModels.UserViewModels;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Core.Interfaces.UserInterfaces
{
    public interface IRecentVisitService
    {
        IQueryable<RecentVisitViewModel> GetUserRecentVisits(int userId);

        OperationResult InsertRecentVisit(RecentVisit visit);

        OperationResult DeleteRecentVisit(RecentVisit visit);

        OperationResult DeleteRecentVisit(int id);
    }
}
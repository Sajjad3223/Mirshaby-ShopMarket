using System.Linq;
using ShopMarket.Core.Interfaces.UserInterfaces;
using ShopMarket.Core.Utilities;
using ShopMarket.Core.Utilities.Mappers;
using ShopMarket.Core.ViewModels.UserViewModels;
using ShopMarket.Domain.Interfaces.UserInterfaces;
using ShopMarket.Domain.UserEntities;

namespace ShopMarket.Core.Services.UserServices
{
    public class RecentVisitService : IRecentVisitService
    {
        private readonly IRecentVisitRepository _visitRepository;

        public RecentVisitService(IRecentVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }

        public OperationResult DeleteRecentVisit(RecentVisit visit)
        {
            try
            {
                if (visit == null)
                    return OperationResult.NotFound();
                _visitRepository.DeleteRecentVisit(visit);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public OperationResult DeleteRecentVisit(int id)
        {
            try
            {
                if (id == null)
                    return OperationResult.NotFound();
                _visitRepository.DeleteRecentVisit(id);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }

        public IQueryable<RecentVisitViewModel> GetUserRecentVisits(int userId)
        {
            return _visitRepository.GetUserRecentVisits(userId).OrderByDescending(rv=>rv.RecentVisitId).Take(10).Select(rv=>rv.MapToViewModel());
        }

        public OperationResult InsertRecentVisit(RecentVisit visit)
        {
            try
            {
                if (visit == null)
                    return OperationResult.NotFound();
                var visits = GetUserRecentVisits(visit.UserId);
                if(visits.Count() > 9)
                    visits.Skip(9).ToList().ForEach(v=>DeleteRecentVisit(v.RecentVisitId));
                _visitRepository.InsertRecentVisit(visit);
                return OperationResult.Success();
            }
            catch
            {
                return OperationResult.Error();
            }
        }
    }
}
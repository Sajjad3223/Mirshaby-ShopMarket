using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Core.Utilities;
using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Core.Interfaces.ShopInterfaces
{
    public interface IDiscountCodeService
    {
        IQueryable<DiscountCode> GetAll();

        Task<DiscountCode> GetCode(int id);

        Task<DiscountCode> GetCode(string code);

        Task<bool> DoesCodeExist(string code);

        Task<bool> IsCodeUsed(string code);

        Task<bool> IsCodeExpired(string code);

        Task<OperationResult> UseDiscountCode(string code);

        Task<DiscountCode> InsertCode(DiscountCode code);

        OperationResult UpdateCode(DiscountCode code);

        OperationResult DeleteCode(DiscountCode code);

        Task<OperationResult> DeleteCode(int id);
        
    }
}
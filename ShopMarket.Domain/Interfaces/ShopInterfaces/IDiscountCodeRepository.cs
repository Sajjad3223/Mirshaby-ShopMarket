using System.Linq;
using System.Threading.Tasks;
using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Domain.Interfaces.ShopInterfaces
{
    public interface IDiscountCodeRepository
    {
        IQueryable<DiscountCode> GetAll();

        Task<DiscountCode> GetCode(int id);

        Task<DiscountCode> GetCode(string code);

        Task<bool> DoesCodeExist(string code);

        void InsertCode(DiscountCode code);

        void UpdateCode(DiscountCode code);

        void DeleteCode(DiscountCode code);

        void DeleteCode(int id);

        void Save();
    }
}
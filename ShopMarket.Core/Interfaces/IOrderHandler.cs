using System.Threading.Tasks;
using ShopMarket.Core.Utilities;

namespace ShopMarket.Core.Interfaces
{
    public interface IOrderHandler
    {
        Task<OperationResult> FinalizeOrder(int orderId,long refId);
    }
}
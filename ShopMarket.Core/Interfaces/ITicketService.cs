using System.Linq;
using ShopMarket.Core.ViewModels;
using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Core.Interfaces
{
    public interface ITicketService
    {
        IQueryable<TicketViewModel> GetAllTickets();
        TicketViewModel GetTicket(int id);

        void InsertTicket(TicketViewModel ticket);
        void SeenTicket(TicketViewModel ticket);
    }
}
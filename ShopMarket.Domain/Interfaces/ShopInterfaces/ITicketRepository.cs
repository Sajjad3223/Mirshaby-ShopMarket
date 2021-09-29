using System.Linq;
using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Domain.Interfaces.ShopInterfaces
{
    public interface ITicketRepository
    {
        IQueryable<Ticket> GetAllTickets();
        Ticket GetTicket(int id);

        void InsertTicket(Ticket ticket);
        void UpdateTicket(Ticket ticket);

        void Save();
    }
}
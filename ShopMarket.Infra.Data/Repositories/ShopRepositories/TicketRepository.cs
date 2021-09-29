using System.Linq;
using ShopMarket.Domain.Interfaces.ShopInterfaces;
using ShopMarket.Domain.ShopEntities;
using ShopMarket.Infra.Data.ShopMarketContext;

namespace ShopMarket.Infra.Data.Repositories.ShopRepositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ShopMarketDbContext _context;

        public TicketRepository(ShopMarketDbContext context)
        {
            _context = context;
        }


        public IQueryable<Ticket> GetAllTickets()
        {
            return _context.Tickets.OrderByDescending(t=>t.CreationDate);
        }

        public Ticket GetTicket(int id)
        {
            return _context.Tickets.FirstOrDefault(t => t.TicketId == id);
        }

        public void InsertTicket(Ticket ticket)
        {
            _context.Add(ticket);
            Save();
        }

        public void UpdateTicket(Ticket ticket)
        {
            _context.Update(ticket);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
using System.Linq;
using ShopMarket.Core.Interfaces;
using ShopMarket.Core.Utilities.Mappers;
using ShopMarket.Core.ViewModels;
using ShopMarket.Domain.Interfaces.ShopInterfaces;

namespace ShopMarket.Core.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }


        public IQueryable<TicketViewModel> GetAllTickets()
        {
            return _ticketRepository.GetAllTickets().Select(t => t.MapToViewModel());
        }

        public TicketViewModel GetTicket(int id)
        {
            return _ticketRepository.GetTicket(id).MapToViewModel();
        }

        public void InsertTicket(TicketViewModel ticket)
        {
            _ticketRepository.InsertTicket(ticket.MapToTicket());
        }

        public void SeenTicket(TicketViewModel ticket)
        {
            ticket.IsSeen = true;
            _ticketRepository.UpdateTicket(ticket.MapToTicket());
        }
    }
}
using ShopMarket.Core.ViewModels;
using ShopMarket.Domain.ShopEntities;

namespace ShopMarket.Core.Utilities.Mappers
{
    public static class TicketMapper
    {
        public static TicketViewModel MapToViewModel(this Ticket ticket)
        {
            return new TicketViewModel()
            {
                TicketId = ticket.TicketId,
                Title = ticket.Title,
                FullName = ticket.FullName,
                Email = ticket.Email,
                Phone = ticket.Phone,
                CreationDate = ticket.CreationDate,
                IsSeen = ticket.IsSeen,
                Text = ticket.Text
            };
        }

        public static Ticket MapToTicket(this TicketViewModel ticketVm)
        {
            return new Ticket()
            {
                TicketId = ticketVm.TicketId,
                Title = ticketVm.Title,
                FullName = ticketVm.FullName,
                Email = ticketVm.Email,
                Phone = ticketVm.Phone,
                CreationDate = ticketVm.CreationDate,
                IsSeen = ticketVm.IsSeen,
                Text = ticketVm.Text
            };
        }
    }
}
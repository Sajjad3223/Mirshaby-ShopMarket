using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopMarket.Core.Interfaces;
using ShopMarket.Core.Security;
using ShopMarket.Core.ViewModels;

namespace ShopMarket.Pages.Admin.Tickets
{
    [PermissionChecker(1003)]
    public class TicketModel : PageModel
    {
        private readonly ITicketService _ticketService;
        private readonly IEmailSender _emailSender;

        public TicketModel(ITicketService ticketService, IEmailSender emailSender)
        {
            _ticketService = ticketService;
            _emailSender = emailSender;
        }

        public TicketViewModel Ticket { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
                return NotFound();

            Ticket = _ticketService.GetTicket(id.Value);
            if (!Ticket.IsSeen)
            {
                _ticketService.SeenTicket(Ticket);
            }

            return Page();
        }

        public IActionResult OnPost(int? id,string answer)
        {
            if (id == null)
                return NotFound();
            Ticket = _ticketService.GetTicket(id.Value);

            _emailSender.Send(Ticket.Email,$"پاسخ به تیکت شما با موضوع : {Ticket.Title}",answer);

            return RedirectToPage("Index");
        }
    }
}

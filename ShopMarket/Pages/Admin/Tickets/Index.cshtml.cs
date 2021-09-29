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
    public class IndexModel : PageModel
    {
        private readonly ITicketService _ticketService;

        public IndexModel(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public IList<TicketViewModel> Tickets { get; set; }

        public void OnGet()
        {
            Tickets = _ticketService.GetAllTickets().ToList();
        }
    }
}

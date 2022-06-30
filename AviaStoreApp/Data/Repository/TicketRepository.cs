using AviaStoreApp.Data.Interfaces;
using AviaStoreApp.Data.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AviaStoreApp.Data.Repository
{
    public class TicketRepository : IAllTickets
    {
        private readonly AppDBContent DBContent;

        public TicketRepository(AppDBContent DBContent)
        {
            this.DBContent = DBContent;
        }
        public IEnumerable<Ticket> Tickets => DBContent.Ticket.Include(c => c.Flight);


        public Ticket getObjectTicket(int TicketId) => DBContent.Ticket.FirstOrDefault(p => p.Id == TicketId);
    }
}

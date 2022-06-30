using System.Collections.Generic;
using AviaStoreApp.Data.Models;

namespace AviaStoreApp.Data.Interfaces
{
    public interface IAllTickets
    {
        IEnumerable<Ticket> Tickets { get; }
        Ticket getObjectTicket(int TicketId);

    }
}

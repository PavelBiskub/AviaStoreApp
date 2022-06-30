using AviaStoreApp.Data.Models;
using System.Collections.Generic;

namespace AviaStoreApp.ViewModels
{
    public class TicketsListViewModel
    {
        public IEnumerable<Ticket> AllTickets { get; set; }
        public string currFlight { get; set; }
    }
}

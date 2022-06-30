using AviaStoreApp.Data.Models;
using System.Collections.Generic;

namespace AviaStoreApp.Data.Interfaces
{
    public interface ITicketsFlight
    {
        IEnumerable<Flight> AllFlights { get;}
    }
}

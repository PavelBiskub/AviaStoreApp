using AviaStoreApp.Data.Interfaces;
using AviaStoreApp.Data.Models;
using System.Collections.Generic;

namespace AviaStoreApp.Data.Repository
{
    public class FlightRepository :ITicketsFlight
    {
        private readonly AppDBContent DBContent;

        public FlightRepository(AppDBContent DBContent)
        {
            this.DBContent = DBContent;
        }

        public IEnumerable<Flight> AllFlights => DBContent.Flight;
    }
}

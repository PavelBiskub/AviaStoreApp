using System;
using System.Collections.Generic;

namespace AviaStoreApp.Data.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string Airline { get; set; }
        public string AirportSend { get; set; }
        public string AirportArrival { get; set; }
        public List<Ticket> Tickets { get; set; }

    }
}

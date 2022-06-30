using AviaStoreApp.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace AviaStoreApp.Data
{
    public class DBObjects
    {
        private static Dictionary<string,Flight> _flight;
        public static Dictionary<string, Flight> Flights
        {
            get
            {
                if (_flight == null)
                {
                    var List = new Flight[]
                    {
                        new Flight { Airline = "Aeroflot", AirportSend = "Bratsk", AirportArrival = "Domodedovo"},
                        new Flight { Airline = "Qantas", AirportSend = "Venice", AirportArrival = "Barcelona" }
                    };

                    _flight = new Dictionary<string, Flight>();
                    foreach (Flight f in List)
                        _flight.Add(f.Airline, f);
                    
                }
                return _flight;
            }
        }

        public static void Initial(AppDBContent content)
        {
            if (!content.Flight.Any())
                content.Flight.AddRange(Flights.Select(c => c.Value));

            if(!content.Ticket.Any())
                content.AddRange(
                    new Ticket { Name = "ABC-123", Price = 500, Type = "economy", IsAvailable = true, Flight = Flights["Aeroflot"] },
                    new Ticket { Name = "AQWE-123", Price = 990, Type = "buisness", IsAvailable = true, Flight = Flights["Qantas"] },
                    new Ticket { Name = "ABTC-123", Price = 500, Type = "economy", IsAvailable = true, Flight = Flights["Qantas"] },
                    new Ticket { Name = "ACCDD-123", Price = 750, Type = "economy", IsAvailable = true, Flight = Flights["Aeroflot"] },
                    new Ticket { Name = "APQC-123", Price = 790, Type = "buisness", IsAvailable = true, Flight = Flights["Aeroflot"] },
                    new Ticket { Name = "AZCX-123", Price = 1200, Type = "buisness", IsAvailable = true, Flight = Flights["Qantas"] }
                );
            content.SaveChanges();
        }


    }
}

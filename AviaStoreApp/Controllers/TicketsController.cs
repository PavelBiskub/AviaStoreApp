using AviaStoreApp.Data.Interfaces;
using AviaStoreApp.Data.Models;
using AviaStoreApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AviaStoreApp.Controllers
{
    public class TicketsController : Controller
    {
        private readonly IAllTickets _allTickets;
        private readonly ITicketsFlight _allFlights;

        public  TicketsController(IAllTickets iAllTickets, ITicketsFlight iTicketsF)
        {
            _allTickets = iAllTickets;
            _allFlights = iTicketsF;
        }
        [Route("Tickets/List")]
        [Route("Tickets/List/{flight}")]
        public ViewResult List(string flight)
        {
            string _flight = flight;
            IEnumerable<Ticket> tickets = null;
            string currFlight = "";
            if (string.IsNullOrEmpty(flight))
            {
                tickets = _allTickets.Tickets.OrderBy(i => i.Id);
            }
            else
            {
                if(string.Equals("Aeroflot", flight, System.StringComparison.OrdinalIgnoreCase))
                {
                    tickets = _allTickets.Tickets.Where(i => i.Flight.Airline.Equals("Aeroflot")).OrderBy(i => i.Id );
                }else if (string.Equals("Qantas", flight, System.StringComparison.OrdinalIgnoreCase)){
                    tickets = _allTickets.Tickets.Where(i => i.Flight.Airline.Equals("Qantas")).OrderBy(i => i.Id);
                }

                currFlight = _flight;

                
            }
            var ticketObj = new TicketsListViewModel
            {
                AllTickets = tickets,
                currFlight = currFlight
            };

            return View(ticketObj);
        }
    }
}

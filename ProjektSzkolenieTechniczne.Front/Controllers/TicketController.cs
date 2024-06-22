using Microsoft.AspNetCore.Mvc;
using ProjektSzkolenieTechniczne.Service.Command.Ticket.BuyTicket;
using SzkolenieTechniczneStorage.Entities;
using SzkolenieTechniczneStorage;

namespace Travel_Agency.Controllers
{
    public class TicketController : Controller
    {
        private readonly TravelAgencyTicketDbContext _repository;

        public TicketController(TravelAgencyTicketDbContext repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult BuyTicket(long tourId)
        {
            var tour = _repository.Tours.Find(tourId);
            if (tour == null)
            {
                return NotFound();
            }

            var command = new BuyTicketCommand
            {
                TourId = tourId
            };

            return View(command);
        }

        [HttpPost]
        public IActionResult BuyTicket(BuyTicketCommand command)
        {
            if (ModelState.IsValid)
            {
                var tour = _repository.Tours.Find(command.TourId);
                var flight = _repository.Flights.Find(command.FlightId);

                if (tour == null || flight == null)
                {
                    return NotFound();
                }

                var ticket = new Ticket
                {
                    TourId = command.TourId,
                    FlightId = command.FlightId,
                    Email = command.Email,
                    Phone = command.Phone,
                    NumberOfTickets = command.NumbersOfTickets
                };

                _repository.Tickets.Add(ticket);
                _repository.SaveChanges();

                return RedirectToAction("Index", "Tour");
            }

            // Display validation errors if any
            return View(command);
        }
    }
}

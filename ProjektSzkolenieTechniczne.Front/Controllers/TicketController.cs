using Microsoft.AspNetCore.Mvc;
using ProjektSzkolenieTechniczne.Service.Command.Ticket.BuyTicket;
using SzkolenieTechniczneStorage.Entities;
using SzkolenieTechniczneStorage;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult BuyTicket(long tourId, long flightId)
        {
            var tour = _repository.Tours.Find(tourId);
            var flight = _repository.Flights.Find(flightId);
            if (tour == null || flight == null)
            {
                return NotFound();
            }

            var command = new BuyTicketCommand
            {
                TourId = tourId,
                FlightId = flightId
            };

            return View(command);
        }

        [HttpPost]
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

            return View(command);
        }
    }
}
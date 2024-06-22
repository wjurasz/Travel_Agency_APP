using Microsoft.AspNetCore.Mvc;
using ProjektSzkolenieTechniczne.Service.Command.Ticket.BuyTicket;
using SzkolenieTechniczneStorage.Repository;

namespace ProjektSzkolenieTechniczne.Front.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITourRepository _repository;

        public TicketController(ITourRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult BuyTicket(long tourId, int numberOfTickets, DateTime tourDate, string email)
        {
            var command = new BuyTicketCommand(tourId, numberOfTickets, tourDate, email);

            var handler = new BuyTicketCommandHandler(_repository);
            var result = handler.Handle(command);
            if (result.IsFailure)
            {

                return View(command);
            }

            return RedirectToAction("Index");
        }


    }
}

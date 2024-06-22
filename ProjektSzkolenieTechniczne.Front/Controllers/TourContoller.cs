using Microsoft.AspNetCore.Mvc;
using ProjektSzkolenieTechniczne.Service.Command.Tour.Add;
using ProjektSzkolenieTechniczne.Service.Command.Tour.Edit;
using SzkolenieTechniczneService.Query.Dtos;
using SzkolenieTechniczneStorage.Entities;
using SzkolenieTechniczneStorage.Repository;

namespace Travel_Agency.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourRepository _repository;

        public TourController(ITourRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var tours = _repository.GetTours()
                .Select(t => new TourDto(t.Id, t.Destination))
                .ToList();

            return View(tours);
        }
        [HttpGet]
        public IActionResult AddTour()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTour(AddTourCommand command)
        {
            if (ModelState.IsValid)
            {
                var tour = new Tour
                {
                    Destination = command.Destination,
                    Year = command.Year,
                    TourTime = command.TourTime,
                    Date = command.Date,
                    ActiveFrom = DateTime.Now,
                    ActiveTo = command.IsActive ? (DateTime?)null : DateTime.Now.AddYears(1)
                };

                _repository.AddTour(tour);
                return RedirectToAction("Index");
            }

            return View(command);
        }

        [HttpGet]
        public IActionResult EditTour(long id)
        {
            var tour = _repository.GetTourById(id);
            if (tour == null)
            {
                return NotFound();
            }

            var command = new EditTourCommand
            {
                Id = tour.Id,
                Destination = tour.Destination,
                Year = tour.Year,
                FlightTime = tour.TourTime
            };

            return View(command);
        }

        [HttpPost]
        public IActionResult EditTour(EditTourCommand command)
        {
            if (ModelState.IsValid)
            {
                var tour = _repository.GetTourById(command.Id);
                if (tour == null)
                {
                    return NotFound();
                }

                tour.Destination = command.Destination;
                tour.Year = command.Year;
                tour.TourTime = command.FlightTime;

                _repository.EditTour(tour);
                return RedirectToAction("Index");
            }

            return View(command);
        }

        [HttpGet]
        public IActionResult DeleteTour(long id)
        {
            var tour = _repository.GetTourById(id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        [HttpPost, ActionName("DeleteTour")]
        public IActionResult DeleteTourConfirmed(long id)
        {
            var tour = _repository.GetTourById(id);
            if (tour == null)
            {
                return NotFound();
            }

            _repository.RemoveTour(id);
            return RedirectToAction("Index");
        }
    }
}

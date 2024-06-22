using Microsoft.AspNetCore.Mvc;
using ProjektSzkolenieTechniczne.Service.Command.Flight.AddFlight;
using SzkolenieTechniczneStorage.Repository;

namespace ProjektSzkolenieTechniczne.Front.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : Controller
    {
        private readonly ITourRepository _repository;

        public FlightController(ITourRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var flights = _repository.GetTours(); 
            return Ok(flights);
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddFlightCommand command)
        {
            var handler = new AddFlightCommandHandler(_repository);
            var result = handler.Handle(command);

            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok();
        }
    }
}

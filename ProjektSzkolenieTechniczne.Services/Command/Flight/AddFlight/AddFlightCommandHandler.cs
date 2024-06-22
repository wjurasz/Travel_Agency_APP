using SzkolenieTechniczneStorage.Repository;

namespace ProjektSzkolenieTechniczne.Service.Command.Flight.AddFlight
{
    public class AddFlightCommandHandler : ICommandHandler<AddFlightCommand>
    {
        private readonly ITourRepository _repository;

        public AddFlightCommandHandler(ITourRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(AddFlightCommand command)
        {
            var validationResult = new AddFlightCommandValidator().Validate(command);
            if (validationResult.IsValid == false)
            {
                return Result.Fail(validationResult);
            }

            var isFlightExist = _repository.IsFlightExist(command.Date);
            if (isFlightExist)
            {
                return Result.Fail("This flight already exists");
            }

            var tour = _repository.GetTourById(command.TourId);
            if (tour == null)
            {
                return Result.Fail("This tour does not exist");
            }

            var flight = new SzkolenieTechniczneStorage.Entities.Flight(command.Date, command.NumberOfTickets, command.TourId);
            _repository.AddFlight(flight);

            return Result.Ok();
        }
    }
}

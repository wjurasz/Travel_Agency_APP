using SzkolenieTechniczneStorage.Repository;

namespace ProjektSzkolenieTechniczne.Service.Command.Tour.Edit
{
    public class EditTourCommandHandler : ICommandHandler<EditTourCommand>
    {
        private readonly ITourRepository _repository;

        public EditTourCommandHandler(ITourRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(EditTourCommand command)
        {
            var validationResult = new EditTourCommandValidator().Validate(command);
            if (validationResult.IsValid == false)
            {
                return Result.Fail(validationResult);
            }

            var tour = _repository.GetTourById(command.Id);
            if (tour == null)
            {
                return Result.Fail("Tour does not exist.");
            }

            tour.Destination = command.Destination;
            tour.Year = command.Year;
            tour.TourTime = command.FlightTime;



            _repository.EditTour(tour);
            return Result.Ok();
        }
    }
}
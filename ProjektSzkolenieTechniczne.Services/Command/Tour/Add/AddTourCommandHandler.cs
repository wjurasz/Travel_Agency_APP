using SzkolenieTechniczneStorage.Repository;

namespace ProjektSzkolenieTechniczne.Service.Command.Tour.Add
{
    public class AddTourCommandHandler : ICommandHandler<AddTourCommand>
    {
        private readonly ITourRepository _repository;

        public AddTourCommandHandler(ITourRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(AddTourCommand command)
        {
            var validationResult = new AddTourCommandValidator().Validate(command);
            if (validationResult.IsValid == false)
            {
                return Result.Fail(validationResult);
            }

            var isExist = _repository.IsTourExist(command.Destination, command.Year);
            if (isExist)
            {
                return Result.Fail("This tour already exists!");
            }


            var tour = new SzkolenieTechniczneStorage.Entities.Tour(
                command.Destination,
                command.TourTime,
                command.Date,
                command.Year
            );

            _repository.AddTour(tour);

            return Result.Ok();
        }
    }
}

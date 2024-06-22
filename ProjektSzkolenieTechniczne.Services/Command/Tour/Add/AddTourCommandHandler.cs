using System;
using SzkolenieTechniczneStorage.Repository;
using SzkolenieTechniczneStorage.Entities;

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
            if (!validationResult.IsValid)
            {
                return Result.Fail(validationResult);
            }

            var isExist = _repository.IsTourExist(command.Destination, command.Year);
            if (isExist)
            {
                return Result.Fail("This tour already exists!");
            }

            var tour = new SzkolenieTechniczneStorage.Entities.Tour
            {
                Destination = command.Destination,
                Year = command.Year,
                TourTime = command.TourTime,
                Date = command.Date,
                NumberOfTickets = command.NumberOfTickets,
                ActiveFrom = DateTime.Now,
                ActiveTo = command.IsActive ? (DateTime?)null : DateTime.Now.AddYears(1)
            };

            var flight = new SzkolenieTechniczneStorage.Entities.Flight
            {
                Date = command.Date,
                NumberOfTickets = command.NumberOfTickets,
                FlightTime = command.FlightTime,
                TourId = tour.Id // This will be set after the tour is saved
            };

            _repository.AddTourWithFlight(tour, flight);

            return Result.Ok();
        }
    }
}

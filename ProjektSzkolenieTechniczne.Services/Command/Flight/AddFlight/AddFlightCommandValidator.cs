using FluentValidation;
using System;

namespace ProjektSzkolenieTechniczne.Service.Command.Flight.AddFlight
{
    public class AddFlightCommandValidator : AbstractValidator<AddFlightCommand>
    {
        public AddFlightCommandValidator()

        {
            RuleFor(x => x.TourId).NotEmpty();
            RuleFor(x => x.NumberOfTickets).NotEmpty().GreaterThan(1);
            RuleFor(x => x.Date).NotEmpty().GreaterThan(DateTime.UtcNow);
        }
    }
}

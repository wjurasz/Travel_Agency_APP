using FluentValidation;
using System;

namespace ProjektSzkolenieTechniczne.Service.Command.Tour.Add
{
    public class AddTourCommandValidator : AbstractValidator<AddTourCommand>
    {
        public AddTourCommandValidator()
        {
            RuleFor(x => x.TourTime).NotEmpty();
            RuleFor(x => x.FlightTime).NotEmpty();
            RuleFor(x => x.Year).NotEmpty();
            RuleFor(x => x.Destination).NotEmpty();
            RuleFor(x => x.Date).NotEmpty().GreaterThan(DateTime.UtcNow);
        }
    }
}

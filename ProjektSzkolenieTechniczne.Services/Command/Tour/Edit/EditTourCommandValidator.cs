using FluentValidation;

namespace ProjektSzkolenieTechniczne.Service.Command.Tour.Edit
{
    public class EditTourCommandValidator : AbstractValidator<EditTourCommand>
    {
        public EditTourCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FlightTime).NotEmpty();
            RuleFor(x => x.Destination).NotEmpty();
            RuleFor(x => x.Year).NotEmpty();
        }

    }
}

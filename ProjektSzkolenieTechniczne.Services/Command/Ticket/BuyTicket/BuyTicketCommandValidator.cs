using FluentValidation;
using System;

namespace ProjektSzkolenieTechniczne.Service.Command.Ticket.BuyTicket
{
    public class BuyTicketCommandValidator : AbstractValidator<BuyTicketCommand>
    {
        public BuyTicketCommandValidator()
        {
            RuleFor(x => x.TourId).NotEmpty();
            RuleFor(x => x.NumbersOfTickets).GreaterThan(10);
            RuleFor(x => x.TourDate).NotEmpty().GreaterThan(DateTime.UtcNow);
            RuleFor(x => x.Email).NotEmpty();




        }


    }
}

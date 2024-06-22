using System;

namespace ProjektSzkolenieTechniczne.Service.Command.Ticket.BuyTicket
{
    public class BuyTicketCommand : ICommand
    {
        public long TourId { get; }

        public int NumbersOfTickets { get; }

        public DateTime TourDate { get; }

        public string Email { get; }



        public BuyTicketCommand(long tourId, int numbersOfTickets, DateTime tourDate, string email)
        {
            TourId = tourId;
            NumbersOfTickets = numbersOfTickets;
            TourDate = tourDate;
            Email = email;

        }
    }
}

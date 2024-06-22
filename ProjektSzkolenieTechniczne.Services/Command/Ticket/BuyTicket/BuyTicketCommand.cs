using System;
using System.ComponentModel.DataAnnotations;

namespace ProjektSzkolenieTechniczne.Service.Command.Ticket.BuyTicket
{
    public class BuyTicketCommand : ICommand
    {
        public long TourId { get; set; }
        public long FlightId { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string Phone { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "You can buy between 1 and 10 tickets.")]
        public int NumbersOfTickets { get; set; }

        public BuyTicketCommand()
        {
        }
    }
}

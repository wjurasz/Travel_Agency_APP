using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SzkolenieTechniczneStorage.Common;

namespace SzkolenieTechniczneStorage.Entities
{
    [Table("Tickets", Schema = "TravelAgency")]
    public class Ticket : BaseEntity
    {
        [Required]
        [MinLength(5)]
        [MaxLength(128)]
        public string Email { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(128)]
        public string Phone { get; set; }

        [Range(1, 18)]
        public int NumberOfTickets { get; set; }

        public Ticket(string email, int numberOfTickets)
        {
            Email = email;
            NumberOfTickets = numberOfTickets;
        }

        [Required]
        public long FlightId { get; set; }
        public Flight Flight { get; set; }

        public long? TourId { get; set; }
        public Tour Tour { get; set; }

        public Ticket() { }
    }
}

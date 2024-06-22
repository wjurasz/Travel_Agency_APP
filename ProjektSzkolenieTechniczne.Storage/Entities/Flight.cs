using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SzkolenieTechniczneStorage.Common;

namespace SzkolenieTechniczneStorage.Entities
{
    [Table("Flight", Schema = "TravelAgency")]
    public class Flight : BaseEntity
    {
        public Flight()
        {
        }

        public Flight(DateTime date, int numberOfTickets, long tourId)
        {
            Date = date;
            TourId = tourId;
            NumberOfTickets = numberOfTickets;
        }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int NumberOfTickets { get; set; }

        [Required]
        public int FlightTime { get; set; }

        [Required]
        public long TourId { get; set; }
        public Tour Tour { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}

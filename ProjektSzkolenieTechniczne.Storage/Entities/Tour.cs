using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SzkolenieTechniczneStorage.Common;

namespace SzkolenieTechniczneStorage.Entities
{
    [Table("Tour", Schema = "TravelAgency")]
    public class Tour : BaseEntity
    {
        public Tour()
        {
        }

        public Tour(string destination, int tourTime, DateTime date, int year)
        {
            Destination = destination;
            TourTime = tourTime;
            Date = date;
            Year = year;
        }

        [Required]
        [MinLength(1)]
        public string Destination { get; set; }

        [Required]
        public int TourTime { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime ActiveFrom { get; set; }
        public DateTime? ActiveTo { get; set; }

        [Required]
        public int NumberOfTickets { get; set; }

        [Required]
        public int Year { get; set; }

        public ICollection<Flight> Flights { get; set; }
    }
}

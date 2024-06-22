using System;
using System.ComponentModel.DataAnnotations;

namespace ProjektSzkolenieTechniczne.Service.Command.Tour.Add
{
    public class AddTourCommand : ICommand
    {
        [Required(ErrorMessage = "The Destination field is required.")]
        public string Destination { get; set; }

        [Required(ErrorMessage = "The Year field is required.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "The TourTime field is required.")]
        public int TourTime { get; set; }

        [Required(ErrorMessage = "The Date field is required.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "The NumberOfTickets field is required.")]
        public int NumberOfTickets { get; set; }

        [Required(ErrorMessage = "The IsActive field is required.")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "The FlightTime field is required.")]
        public int FlightTime { get; set; }

       
        public AddTourCommand() { }

        public AddTourCommand(string destination, bool isActive, int year, int tourTime, DateTime date, int flightTime, int numberOfTickets)
        {
            Destination = destination;
            Year = year;
            TourTime = tourTime;
            Date = date;
            IsActive = isActive;
            FlightTime = flightTime;
            NumberOfTickets = numberOfTickets;
        }
    }
}

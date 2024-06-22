using System;

namespace ProjektSzkolenieTechniczne.Service.Command.Tour.Add
{
    public class AddTourCommand : ICommand
    {
        public string Destination { get; }

        public int Year { get; }

        public int TourTime { get; }

        public DateTime Date { get; }

        public int FlightTime { get; }

        public bool IsActive { get; }

        public AddTourCommand()
        {
        }

        public AddTourCommand(string destination, bool isActive, int year, int tourTime, DateTime date, int flightTime)
        {
            Destination = destination;
            Year = year;
            TourTime = tourTime;
            Date = date;
            IsActive = isActive;
            FlightTime = flightTime;
        }
    }
}

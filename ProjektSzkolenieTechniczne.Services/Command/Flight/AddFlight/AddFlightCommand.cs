using System;

namespace ProjektSzkolenieTechniczne.Service.Command.Flight.AddFlight
{
    public class AddFlightCommand : ICommand
    {
        public DateTime Date { get; }
        public long TourId { get; }
        public int NumberOfTickets { get; }

        public AddFlightCommand(long tourId, DateTime date, int numberOfTickets)
        {
            Date = date;
            TourId = tourId;
            NumberOfTickets = numberOfTickets;
        }
    }
}

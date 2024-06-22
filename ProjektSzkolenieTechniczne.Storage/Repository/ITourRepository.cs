using SzkolenieTechniczneStorage.Entities;
using System;
using System.Collections.Generic;

namespace SzkolenieTechniczneStorage.Repository
{
    public interface ITourRepository
    {
        List<Tour> GetTours();
        Tour GetTourById(long tourId);
        Flight GetFlightById(long flightId);
        void AddTourWithFlight(Tour tour, Flight flight); // Dodanie tej metody
        void EditTour(Tour tour);
        void RemoveTour(long id);
        bool IsTourExist(long id);
        bool IsTourExist(string destination, int year);
        bool IsFlightExist(DateTime date);
        void AddFlight(Flight flight);
        void BuyTicket(Ticket ticket);
        List<Flight> GetFlightByTourId(long tourId);
        List<Flight> GetFlightByDate(DateTime date);
        Tour GetFlightDetails(long tourId);
    }
}

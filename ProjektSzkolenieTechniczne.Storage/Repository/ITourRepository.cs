using System;
using System.Collections.Generic;
using SzkolenieTechniczneStorage.Entities;

namespace SzkolenieTechniczneStorage.Repository
{
    public interface ITourRepository 
    {
        List<Entities.Tour> GetTours();
        Entities.Tour GetTourById(long TourId);

        Entities.Flight GetFlightById(long FlightId);

        void AddTour(Entities.Tour movie);
        void EditTour(Entities.Tour movie);
        void RemoveTour(long id);
        bool IsTourExist(long id);
        bool IsTourExist(string destination, int year);
        bool IsFlightExist(DateTime date);
        void AddFlight(Entities.Flight flight);

        List<Flight> GetFlightByTourId(long tourId);

        List<Flight> GetFlightByDate(DateTime date);
     
        Entities.Tour GetFlightDetails(long tourId);



    }
}

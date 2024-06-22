using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using SzkolenieTechniczneStorage.Entities;

namespace SzkolenieTechniczneStorage.Repository
{
    public class TourRepository : ITourRepository
    {
        private readonly TravelAgencyTicketDbContext _repository;

        public TourRepository(TravelAgencyTicketDbContext repository)
        {
            _repository = repository;
        }

        public void AddTour(Entities.Tour tour)
        {
            _repository.Tours.Add(tour);
            _repository.SaveChanges();
        }

        public void AddFlight(Flight flight)
        {
            _repository.Flights.Add(flight);
            _repository.SaveChanges();
        }

        public void BuyTicket(Ticket ticket)
        {
            _repository.Tickets.Add(ticket);
            _repository.SaveChanges();
        }

        public void EditTour(Entities.Tour tour)
        {
            _repository.Tours.Update(tour);
            _repository.SaveChanges();
        }

        public Entities.Tour GetTourById(long tourId)
        {
            return _repository.Tours
                  .Include(c => c.Flights)
                  .ThenInclude(c => c.Tickets)
                  .SingleOrDefault(x => x.Id == tourId);
        }

        public List<Entities.Tour> GetTours()
        {
            return _repository.Tours.ToList();
        }

        public Entities.Tour GetFlightDetails(long tourId)
        {
            return _repository.Tours.Where(x => x.Id == tourId)
              .Include(t => t.Flights)
              .SingleOrDefault();
        }

        public List<Flight> GetFlightByTourId(long tourId)
        {
            return _repository.Flights.Where(x => x.TourId == tourId)
               .ToList();
        }

        public Flight GetFlightById(long flightId)
        {
            return _repository.Flights
                .Include(f => f.Tickets)
                .SingleOrDefault(x => x.Id == flightId);
        }

        public List<Flight> GetFlightByDate(DateTime date)
        {
            return _repository.Flights
                .Where(x => x.Date.Date == date.Date)
                .Include(f => f.Tickets)
                .ToList();
        }

        public bool IsTourExist(long tourId)
        {
            return _repository.Tours.Any(
                 x => x.Id == tourId);
        }

        public bool IsTourExist(string destination, int year)
        {
            return _repository.Tours.Any(
                  x => x.Destination == destination && x.Year == year);
        }

        public bool IsFlightExist(DateTime date)
        {
            return _repository.Flights.Any(x => x.Date == date);
        }

        public void RemoveTour(long id)
        {
            var tour = _repository.Tours.FirstOrDefault(x => x.Id == id);
            _repository.Remove(tour);
            _repository.SaveChanges();
        }
    }
}

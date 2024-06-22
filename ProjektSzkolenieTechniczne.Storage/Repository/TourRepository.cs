using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using SzkolenieTechniczneStorage.Entities;

namespace SzkolenieTechniczneStorage.Repository
{
    public class TourRepository : ITourRepository
    {
        private readonly TravelAgencyTicketDbContext _context;

        public TourRepository(TravelAgencyTicketDbContext context)
        {
            _context = context;
        }

        public void AddTour(Entities.Tour tour)
        {
            _context.Tours.Add(tour);
            _context.SaveChanges();
        }

        public void AddFlight(Flight flight)
        {
            _context.Flights.Add(flight);
            _context.SaveChanges();
        }

        public void BuyTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }

        public void EditTour(Entities.Tour tour)
        {
            _context.Tours.Update(tour);
            _context.SaveChanges();
        }

        public Entities.Tour GetTourById(long tourId)
        {
            return _context.Tours
                  .Include(c => c.Flights)
                  .ThenInclude(c => c.Tickets)
                  .SingleOrDefault(x => x.Id == tourId);
        }

        public List<Entities.Tour> GetTours()
        {
            return _context.Tours.ToList();
        }

        public Entities.Tour GetFlightDetails(long tourId)
        {
            return _context.Tours.Where(x => x.Id == tourId)
              .Include(t => t.Flights)
              .SingleOrDefault();
        }

        public List<Flight> GetFlightByTourId(long tourId)
        {
            return _context.Flights.Where(x => x.TourId == tourId)
               .ToList();
        }

        public Flight GetFlightById(long flightId)
        {
            return _context.Flights
                .Include(f => f.Tickets)
                .SingleOrDefault(x => x.Id == flightId);
        }

        public List<Flight> GetFlightByDate(DateTime date)
        {
            return _context.Flights
                .Where(x => x.Date.Date == date.Date)
                .Include(f => f.Tickets)
                .ToList();
        }

        public bool IsTourExist(long tourId)
        {
            return _context.Tours.Any(
                 x => x.Id == tourId);
        }

        public bool IsTourExist(string destination, int year)
        {
            return _context.Tours.Any(
                  x => x.Destination == destination && x.Year == year);
        }

        public bool IsFlightExist(DateTime date)
        {
            return _context.Flights.Any(x => x.Date == date);
        }

        public void RemoveTour(long id)
        {
            var tour = _context.Tours.FirstOrDefault(x => x.Id == id);
            _context.Remove(tour);
            _context.SaveChanges();
        }
    }
}

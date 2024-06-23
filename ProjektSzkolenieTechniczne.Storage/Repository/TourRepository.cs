using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczneStorage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SzkolenieTechniczneStorage.Repository
{
    public class TourRepository : ITourRepository
    {
        private readonly TravelAgencyTicketDbContext _context;

        public TourRepository(TravelAgencyTicketDbContext context)
        {
            _context = context;
        }

        public void AddTourWithFlight(Tour tour, Flight flight)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Tours.Add(tour);
                _context.SaveChanges();

                flight.TourId = tour.Id; // Assign the newly created Tour's Id to the Flight
                _context.Flights.Add(flight);
                _context.SaveChanges();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public void EditTour(Tour tour)
        {
            _context.Tours.Update(tour);
            _context.SaveChanges();
        }

        public void RemoveTour(long id)
        {
            var tour = _context.Tours
                .Include(t => t.Flights)
                .ThenInclude(f => f.Tickets)
                .FirstOrDefault(t => t.Id == id);

            if (tour != null)
            {
                foreach (var flight in tour.Flights)
                {
                    _context.Tickets.RemoveRange(flight.Tickets);
                }
                _context.Flights.RemoveRange(tour.Flights);
                _context.Tours.Remove(tour);
                _context.SaveChanges();
            }
        }

        public List<Tour> GetTours()
        {
            return _context.Tours.Include(t => t.Flights).ToList();
        }

        public Tour GetTourById(long tourId)
        {
            return _context.Tours.Include(t => t.Flights).SingleOrDefault(t => t.Id == tourId);
        }

        public Flight GetFlightById(long flightId)
        {
            return _context.Flights.Include(f => f.Tickets).SingleOrDefault(f => f.Id == flightId);
        }

        public bool IsTourExist(long id)
        {
            return _context.Tours.Any(t => t.Id == id);
        }

        public bool IsTourExist(string destination, int year)
        {
            return _context.Tours.Any(t => t.Destination == destination && t.Year == year);
        }

        public bool IsFlightExist(DateTime date)
        {
            return _context.Flights.Any(f => f.Date == date);
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

        public List<Flight> GetFlightByTourId(long tourId)
        {
            return _context.Flights.Where(f => f.TourId == tourId).ToList();
        }

        public List<Flight> GetFlightByDate(DateTime date)
        {
            return _context.Flights.Where(f => f.Date.Date == date.Date).ToList();
        }

        public Tour GetFlightDetails(long tourId)
        {
            return _context.Tours.Where(t => t.Id == tourId).Include(t => t.Flights).SingleOrDefault();
        }
    }
}

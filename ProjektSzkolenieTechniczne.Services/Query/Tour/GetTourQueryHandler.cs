using System;
using System.Collections.Generic;
using System.Linq;
using SzkolenieTechniczneService.Query;
using SzkolenieTechniczneService.Query.Dtos;
using SzkolenieTechniczneStorage.Repository;

namespace ProjektSzkolenieTechniczne.Services.Query.Tour
{
    public class GetTourQueryHandler : IQueryHandler<GetTourQuery, TourDetailsDto>
    {

        private readonly ITourRepository _repository;

        public GetTourQueryHandler(ITourRepository repository)
        {
            _repository = repository;
        }



        public TourDetailsDto Handle(GetTourQuery query)
        {
            var tour = _repository.GetTourById(query.TourId);
            if (tour == null)
            {
                throw new NullReferenceException("Tour does not exist");
            }

            var flights = new List<FlightDto>();
            if (tour.Flights != null)
            {
                flights = tour.Flights.Select(item => new FlightDto(item.Id, item.Date)).ToList();
            }

            return new TourDetailsDto(tour.Id, tour.Destination, tour.Year, tour.TourTime);
        }
    }
}

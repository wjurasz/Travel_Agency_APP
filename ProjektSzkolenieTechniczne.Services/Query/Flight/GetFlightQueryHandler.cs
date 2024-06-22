using System;
using SzkolenieTechniczneService.Query;
using SzkolenieTechniczneService.Query.Dtos;
using SzkolenieTechniczneStorage.Repository;

namespace ProjektSzkolenieTechniczne.Services.Query.Flight
{
    public class GetFlightQueryHandler : IQueryHandler<GetFlightQuery, TourFlightDetailsDto>
    {

        private readonly ITourRepository _repository;

        public GetFlightQueryHandler(ITourRepository repository)
        {
            _repository = repository;
        }

        public TourFlightDetailsDto Handle(GetFlightQuery query)
        {
            var tour = _repository.GetFlightDetails(query.TourId);
            if (tour == null)
            {
                throw new NullReferenceException("Tour does not exist");
            }

            var flights = _repository.GetFlightDetails(query.FlightId);
            if (flights == null)
            {
                throw new NullReferenceException("Flight does not exist");
            }

            return new TourFlightDetailsDto(tour.Id, flights.Id, tour.Destination);


        }
    }
}

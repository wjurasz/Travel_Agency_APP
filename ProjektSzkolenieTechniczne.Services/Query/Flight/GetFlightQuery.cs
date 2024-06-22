using SzkolenieTechniczneService.Query;
using SzkolenieTechniczneService.Query.Dtos;

namespace ProjektSzkolenieTechniczne.Services.Query.Flight
{
    public class GetFlightQuery : IQuery<TourFlightDetailsDto>
    {


        public long TourId { get; set; }

        public long FlightId { get; set; }

        public GetFlightQuery(long tourId, long flightId)
        {
            TourId = tourId;
            FlightId = flightId;
        }
    }
}

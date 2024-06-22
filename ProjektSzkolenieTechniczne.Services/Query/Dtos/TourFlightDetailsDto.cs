namespace SzkolenieTechniczneService.Query.Dtos
{
    public class TourFlightDetailsDto
    {

        public long TourId { get; set; }

        public string Destination { get; set; }

        public long FlightId { get; set; }



        public TourFlightDetailsDto(long tourId, long flightId, string destination)
        {
            TourId = tourId;
            FlightId = flightId;
            Destination = destination;

        }
    }
}

namespace SzkolenieTechniczneService.Query.Dtos
{
    public class TourDto
    {
        public long Id { get; set; }

        public string Destination { get; set; }

        public long FlightId { get; set; }

        public TourDto(long id, string destination, long flightId)
        {
            Id = id;
            Destination = destination;
            FlightId = flightId;
        }
    }
}

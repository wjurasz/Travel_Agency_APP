namespace SzkolenieTechniczneService.Query.Dtos
{
    public class TourDetailsDto
    {

        public long Id { get; }

        public string Destination { get; }

        public int Year { get; }

        public int TourTime { get; }
        public TourDetailsDto(long id, string destination, int year, int tourTime)
        {
            Id = id;
            Destination = destination;
            Year = year;
            TourTime = tourTime;
        }
    }
}

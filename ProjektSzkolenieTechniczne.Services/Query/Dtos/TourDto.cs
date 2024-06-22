namespace SzkolenieTechniczneService.Query.Dtos
{
    public class TourDto
    {
        public long Id { get; set; }

        public string Destination { get; set; }

        public TourDto(long id, string destination)
        {
            Id = id;
            Destination = destination;
        }
    }
}

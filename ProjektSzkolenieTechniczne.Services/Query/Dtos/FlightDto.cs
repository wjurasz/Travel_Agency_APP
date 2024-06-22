using System;

namespace SzkolenieTechniczneService.Query.Dtos
{
    public class FlightDto
    {
        public long Id { get; set; }

        public DateTime? Date { get; set; }

        public FlightDto(long id, DateTime? date)
        {
            Id = id;
            Date = date;
        }
    }
}

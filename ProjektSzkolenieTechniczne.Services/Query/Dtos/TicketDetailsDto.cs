using System;

namespace SzkolenieTechniczneService.Query.Dtos
{
    public class TicketDetailsDto
    {
        public TicketDetailsDto(string email, int peopleCount, DateTime purchesDate)
        {
            Email = email;
            PeopleCount = peopleCount;
            PurchesDate = purchesDate;
        }

        public string Email { get; }

        public int PeopleCount { get; }

        public DateTime PurchesDate { get; }
    }
}

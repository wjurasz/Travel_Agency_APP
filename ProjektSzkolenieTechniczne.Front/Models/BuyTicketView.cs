namespace ProjektSzkolenieTechniczne.Front.Models
{
    public class BuyTicketView
    {
        public class BuyTicketViewModel
        {
            public long TourId { get; set; }

            public string Destination { get; set; }

            public long FlightId { get; set; }

            public DateTime Date { get; set; }


        }

    }
}

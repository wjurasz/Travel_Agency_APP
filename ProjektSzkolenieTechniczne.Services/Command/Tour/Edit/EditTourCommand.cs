namespace ProjektSzkolenieTechniczne.Service.Command.Tour.Edit
{
    public class EditTourCommand : ICommand
    {
        public long Id { get; set; }

        public string Destination { get; set; }

        public int Year { get; set; }

        public int FlightTime { get; set; }

       
    }
}

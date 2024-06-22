namespace ProjektSzkolenieTechniczne.Service.Command.Tour.Delete
{
    public class DeleteTourCommand : ICommand
    {
        public long Id { get; set; }
        public string Destination { get; set; }
        public int Year { get; set; }

        // Parameterless constructor
        public DeleteTourCommand() { }

        public DeleteTourCommand(long id)
        {
            Id = id;
        }

        public DeleteTourCommand(long id, string destination, int year)
        {
            Id = id;
            Destination = destination;
            Year = year;
        }
    }
}

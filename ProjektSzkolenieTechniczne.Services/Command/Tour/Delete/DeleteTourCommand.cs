namespace ProjektSzkolenieTechniczne.Service.Command.Tour.Delete
{
    public class DeleteTourCommand : ICommand
    {
        public long Id { get; }

        public DeleteTourCommand(long id)
        {
            Id = id;
        }
    }
}

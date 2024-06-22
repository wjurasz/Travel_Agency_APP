using SzkolenieTechniczneStorage.Repository;

namespace ProjektSzkolenieTechniczne.Service.Command.Tour.Delete
{
    public class DeleteTourCommandHandler : ICommandHandler<DeleteTourCommand>
    {
        private readonly ITourRepository _repository;

        public DeleteTourCommandHandler(ITourRepository repository)
        {
            _repository = repository;
        }
        public Result Handle(DeleteTourCommand command)
        {
            var tour = _repository.GetTourById(command.Id);
            if (tour == null)
            {
                return Result.Fail("Tour does not exist!");
            }
            _repository.RemoveTour(command.Id);

            return Result.Ok();
        }

    }
}

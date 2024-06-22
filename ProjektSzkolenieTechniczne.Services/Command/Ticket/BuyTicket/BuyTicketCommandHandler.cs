using SzkolenieTechniczneStorage.Repository;

namespace ProjektSzkolenieTechniczne.Service.Command.Ticket.BuyTicket
{
    public class BuyTicketCommandHandler : ICommandHandler<BuyTicketCommand>
    {
        private readonly ITourRepository _repository;

        public BuyTicketCommandHandler(ITourRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(BuyTicketCommand command)
        {
            var validationResult = new BuyTicketCommandValidator().Validate(command);
            if (validationResult.IsValid == false)
            {
                return Result.Fail(validationResult);
            }

            var tour = _repository.GetTourById(command.TourId);
            if (tour == null)
            {
                return Result.Fail("Tour does not exist");
            }

            



            return Result.Ok();
        }
    }
}

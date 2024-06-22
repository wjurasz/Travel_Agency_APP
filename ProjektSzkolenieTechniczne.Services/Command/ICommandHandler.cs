namespace ProjektSzkolenieTechniczne.Service.Command
{
    internal interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }
}

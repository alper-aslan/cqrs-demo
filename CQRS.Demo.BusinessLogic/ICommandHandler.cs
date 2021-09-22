namespace CQRS.Demo.BusinessLogic
{
    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }
}

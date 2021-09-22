namespace CQRS.Demo.BusinessLogic.Decorators
{
    // This is the base template for a command handler decorator
    public class CommandHandlerDecorator<TCommand>
        : ICommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> decoratee;

        public CommandHandlerDecorator(
            ICommandHandler<TCommand> decoratee)
        {
            this.decoratee = decoratee;
        }

        public void Handle(TCommand command)
        {
            decoratee.Handle(command);
        }
    }
}

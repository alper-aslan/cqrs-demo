using System.Transactions;

namespace CQRS.Demo.BusinessLogic.Decorators
{
    public class TransactionCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> decoratee;

        public TransactionCommandHandlerDecorator(ICommandHandler<TCommand> decoratee)
        {
            this.decoratee = decoratee;
        }

        public void Handle(TCommand command)
        {
            using var scope = new TransactionScope();
            decoratee.Handle(command);
        }
    }
}
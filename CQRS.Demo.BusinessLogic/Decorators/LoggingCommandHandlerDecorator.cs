using System;
using CQRS.Demo.BusinessLogic.Helpers;

namespace CQRS.Demo.BusinessLogic.Decorators
{
    public class LoggingCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> decoratee;

        public LoggingCommandHandlerDecorator(ICommandHandler<TCommand> decoratee)
        {
            this.decoratee = decoratee;
        }

        public void Handle(TCommand command)
        {
            Logger.Log(
                $"Executing {typeof(TCommand)}");

            try
            {
                decoratee.Handle(command);
                Logger.Log($"{typeof(TCommand)} successfully executed");
            }
            catch (Exception ex)
            {
                Logger.Log($"{typeof(TCommand)} failed.", ex);
                throw;
            }
        }
    }
}

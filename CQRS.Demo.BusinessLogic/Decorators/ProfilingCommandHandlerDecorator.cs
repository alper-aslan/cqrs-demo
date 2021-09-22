using CQRS.Demo.BusinessLogic.Helpers;

namespace CQRS.Demo.BusinessLogic.Decorators
{
    public class ProfilingCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> decoratee;

        public ProfilingCommandHandlerDecorator(ICommandHandler<TCommand> decoratee)
        {
            this.decoratee = decoratee;
        }

        public void Handle(TCommand command)
        {
            using var profiler = new PerformanceProfiler();
            profiler.StartMeasurement();
            decoratee.Handle(command);
        }
    }
}

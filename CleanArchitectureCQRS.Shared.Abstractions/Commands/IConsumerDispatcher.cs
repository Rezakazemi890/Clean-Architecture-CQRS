namespace CleanArchitectureCQRS.Shared.Abstractions.Commands;

public interface IConsumerDispatcher
{
    Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
}

namespace CleanArchitectureCQRS.Shared.Abstractions.Commands;

    public interface IConsumeHandler<in TCommand> where TCommand : class, ICommand
    {
        Task HandleAsync(TCommand command);
    }

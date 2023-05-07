using CleanArchitectureCQRS.Shared.Abstractions.Commands;
using CleanArchitectureCQRS.Shared.Abstractions.Queries;
using Microsoft.Extensions.DependencyInjection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CleanArchitectureCQRS.Shared.Commands;

internal sealed class InMemoryConsumeDispatcher : IConsumerDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public InMemoryConsumeDispatcher(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand
    {
        try
        {
            using var scope = _serviceProvider.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<IConsumeHandler<TCommand>>();
            
            await handler.HandleAsync(command);
        }
        catch (Exception ex)
        {

        }

    }
}


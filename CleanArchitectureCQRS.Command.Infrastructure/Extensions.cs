using CleanArchitectureCQRS.Shared.Abstractions.Commands;
using CleanArchitectureCQRS.Shared.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitectureCQRS.Shared.Logging;
using CleanArchitectureCQRS.Command.Infrastructure.Logging;
using CleanArchitectureCQRS.Command.Infrastructure.Producers;

namespace CleanArchitectureCQRS.Command.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddSQLDB(configuration);
        //services.AddQueries();
        services.AddSerilog(configuration);
        //services.AddSingleton<IExternalService, ExternalService>();
        services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));
        services.AddRabbitMQProducer(configuration);
        return services;
    }
}

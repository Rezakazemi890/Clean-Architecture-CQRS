using CleanArchitectureCQRS.Query.Infrastructure.Consumer;
using CleanArchitectureCQRS.Query.Infrastructure.EF;
using CleanArchitectureCQRS.Query.Infrastructure.Logging;
using CleanArchitectureCQRS.Query.Infrastructure.Services;
using CleanArchitectureCQRS.Shared.Abstractions.Commands;
using CleanArchitectureCQRS.Shared.Logging;
using CleanArchitectureCQRS.Shared.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitectureCQRS.Shared.Consumers;
using CleanArchitectureCQRS.Domain.Factories;

namespace CleanArchitectureCQRS.Query.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSQLDB(configuration);
        services.AddQueries();
        services.AddConsumers();
        services.AddSerilog(configuration);
        services.AddRabbitMQConsumer(configuration);
        //services.AddSingleton<IExternalService, ExternalService>();
        services.AddSingleton<ISampleEntityFactory, SampleEntityFactory>();
        services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));

        return services;
    }
}

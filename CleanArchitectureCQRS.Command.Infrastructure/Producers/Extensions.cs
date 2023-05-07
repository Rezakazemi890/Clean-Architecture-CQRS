using CleanArchitectureCQRS.Shared.Producers;
using CleanArchitectureCQRS.Shared.Rabbit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace CleanArchitectureCQRS.Command.Infrastructure.Producers;

internal static class Extensions
{
    public static IServiceCollection AddRabbitMQProducer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IRabbitConnectionBuilder, RabbitConnectionBuilder>();
        services.AddScoped<IMessageProducer, RabbitMQProducer>();
        return services;
    }
}
using System.Reflection;
using CleanArchitectureCQRS.Shared.Abstractions.Commands;
using CleanArchitectureCQRS.Shared.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureCQRS.Shared.Consumers;

public static class Extensions
{
    public static IServiceCollection AddConsumers(this IServiceCollection services)
    {
        var assembly = Assembly.GetCallingAssembly();

        services.AddSingleton<IConsumerDispatcher, InMemoryConsumeDispatcher>();

        services.Scan(s => s.FromAssemblies(assembly)
            .AddClasses(c => c.AssignableTo(typeof(IConsumeHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}


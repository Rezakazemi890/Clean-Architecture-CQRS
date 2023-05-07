using CleanArchitectureCQRS.Shared.Consumers;
using CleanArchitectureCQRS.Shared.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureCQRS.Query.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddQueries();

        return services;
    }
}

using CleanArchitectureCQRS.Command.Application.Services;
using CleanArchitectureCQRS.Domain.Repositories;
using CleanArchitectureCQRS.Query.Infrastructure.EF.Contexts;
using CleanArchitectureCQRS.Query.Infrastructure.EF.Options;
using CleanArchitectureCQRS.Query.Infrastructure.EF.Repositories;
using CleanArchitectureCQRS.Query.Infrastructure.EF.Services;
using CleanArchitectureCQRS.Shared.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureCQRS.Query.Infrastructure.EF;

internal static class Extensions
{
    public static IServiceCollection AddSQLDB(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISampleEntityRepository, SampleEntityRepository>();
        services.AddScoped<ISampleEntityReadService, SampleEntityReadService>();

        var options = configuration.GetOptions<DataBaseOptions>("DataBaseConnectionString");
        services.AddDbContext<ReadDbContext>(ctx =>
        ctx.UseSqlServer(options.ConnectionString));

        services.AddDbContext<WriteDbContext>(ctx =>
            ctx.UseSqlServer(options.ConnectionString));

        return services;
    }
}

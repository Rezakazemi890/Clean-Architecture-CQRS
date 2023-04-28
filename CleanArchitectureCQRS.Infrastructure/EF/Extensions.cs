using CleanArchitectureCQRS.Application.Services;
using CleanArchitectureCQRS.Domain.Repositories;
using CleanArchitectureCQRS.Infrastructure.EF.Contexts;
using CleanArchitectureCQRS.Infrastructure.EF.Options;
using CleanArchitectureCQRS.Infrastructure.EF.Repositories;
using CleanArchitectureCQRS.Infrastructure.EF.Services;
using CleanArchitectureCQRS.Shared.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureCQRS.Infrastructure.EF;

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

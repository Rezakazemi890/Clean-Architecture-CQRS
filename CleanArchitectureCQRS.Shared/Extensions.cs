using CleanArchitectureCQRS.Shared.Exceptions;
using CleanArchitectureCQRS.Shared.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureCQRS.Shared;

    public static class Extensions
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            services.AddHostedService<AppInitializer>();
            services.AddScoped<ExceptionMiddleware>();
            return services;
        }

        public static IApplicationBuilder UseShared(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            return app;
        }
    }


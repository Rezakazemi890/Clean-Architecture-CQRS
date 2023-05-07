using System;
using CleanArchitectureCQRS.Query.Infrastructure.BackgroundServices;
using CleanArchitectureCQRS.Shared.Consumers;
using CleanArchitectureCQRS.Shared.Producers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CleanArchitectureCQRS.Query.Infrastructure.Consumer
{
    internal static class Extension
    {
        public static IServiceCollection AddRabbitMQConsumer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMessageConsumer, MessageConsumer>();
            services.AddHostedService<MessageConsumerService>();
            return services;
        }
    }
}


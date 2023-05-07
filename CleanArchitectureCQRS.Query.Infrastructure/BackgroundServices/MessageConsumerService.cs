using System;
using System.Text;
using System.Text.Json;
using CleanArchitectureCQRS.Shared.Abstractions.Commands;
using CleanArchitectureCQRS.Shared.Consumers;
using CleanArchitectureCQRS.Shared.Rabbit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CleanArchitectureCQRS.Query.Infrastructure.BackgroundServices
{
    public class MessageConsumerService : IHostedService
    {
        private readonly ILogger<MessageConsumerService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public MessageConsumerService(ILogger<MessageConsumerService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            using (IServiceScope Scop = _serviceProvider.CreateScope())
            {
                var consumer = Scop.ServiceProvider.GetRequiredService<IMessageConsumer>();
                
                Task.Run(() => consumer.Consume(), cancellationToken);
            }
            _logger.LogInformation("Consumer Service Started");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Consumer Service Stoped");
            return Task.CompletedTask;
        }
    }
}


using System;
using System.Text;
using System.Text.Json;
using CleanArchitectureCQRS.Shared.Abstractions.Commands;
using CleanArchitectureCQRS.Shared.Consumers;
using CleanArchitectureCQRS.Shared.Converters;
using CleanArchitectureCQRS.Shared.Rabbit;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CleanArchitectureCQRS.Query.Infrastructure.Consumer
{
    public class MessageConsumer : IMessageConsumer
    {
        private readonly IRabbitConnectionBuilder _rabbitConnectionBuilder;
        private readonly IConsumerDispatcher _consumerDispatcher;

        public MessageConsumer(IRabbitConnectionBuilder rabbitConnectionBuilder, IConsumerDispatcher consumerDispatcher)
        {
            _rabbitConnectionBuilder = rabbitConnectionBuilder;
            _consumerDispatcher = consumerDispatcher;
        }

        public void Consume()
        {

            var channel = _rabbitConnectionBuilder.CreateConnection() as IModel;
            MessageJsonConverter jsonConverter = new MessageJsonConverter();
            var options = new JsonSerializerOptions { Converters = { new MessageJsonConverter() } };

            while (true)
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, eventArgs) =>
                {
                    var body = eventArgs.Body.ToArray();

                    var message = Encoding.UTF8.GetString(body);

                    var command = JsonSerializer.Deserialize<ICommand>(message, options);

                    _consumerDispatcher.DispatchAsync(command);
                    //_logger.LogInformation($"Message received: {message}");

                    //
                };

                channel.BasicConsume(queue: "sampleEntityQueue", autoAck: true, consumer: consumer);

            }
        }
    }
}


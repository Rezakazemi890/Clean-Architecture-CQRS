using System;
using System.Text;
using CleanArchitectureCQRS.Shared.Consumers;
using CleanArchitectureCQRS.Shared.Rabbit;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CleanArchitectureCQRS.Query.Infrastructure.Consumer
{
    public class MessageConsumer : IMessageConsumer
    {
        private readonly IRabbitConnectionBuilder _rabbitConnectionBuilder;

        public MessageConsumer(IRabbitConnectionBuilder rabbitConnectionBuilder)
        {
            _rabbitConnectionBuilder = rabbitConnectionBuilder;
        }

        public void Consume()
        {

            var channel = _rabbitConnectionBuilder.CreateConnection() as IModel;

            while (true)
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, eventArgs) =>
                {
                    var body = eventArgs.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    //_logger.LogInformation($"Message received: {message}");

                    //var command = JsonSerializer.Deserialize(message, typeof(ICommand));
                };

                channel.BasicConsume(queue: "sampleEntityQueue", autoAck: true, consumer: consumer);

            }
        }
    }
}


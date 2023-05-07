using System;
using System.Text;
using CleanArchitectureCQRS.Shared.Consumers;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CleanArchitectureCQRS.Query.Infrastructure.Consumer
{
    public class MessageConsumer : IMessageConsumer
    {
        private readonly IConfiguration _configuration;

        public MessageConsumer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Consume()
        {
            var factory = new ConnectionFactory
            {
                HostName = _configuration.GetSection("RabbitMQ").GetChildren().First(x => x.Key == "HostName").Value,
                UserName = _configuration.GetSection("RabbitMQ").GetChildren().First(x => x.Key == "UserName").Value,
                Password = _configuration.GetSection("RabbitMQ").GetChildren().First(x => x.Key == "Password").Value,
                //AutomaticRecoveryEnabled = true
            };

            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("sampleEntityQueue", exclusive: false);


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


using System;
using RabbitMQ.Client;
using System.Text;
using CleanArchitectureCQRS.Shared.Producers;
using Microsoft.Extensions.Configuration;
using CleanArchitectureCQRS.Shared.Rabbit;
using System.Text.Json;

namespace CleanArchitectureCQRS.Command.Infrastructure.Producers
{
    public class RabbitMQProducer : IMessageProducer
    {
        private readonly IRabbitConnectionBuilder _rabbitConnectionBuilder;

        public RabbitMQProducer(IRabbitConnectionBuilder rabbitConnectionBuilder)
        {
            _rabbitConnectionBuilder = rabbitConnectionBuilder;
        }

        public void SendMessage<T>(T message)
        {

            var channel = _rabbitConnectionBuilder.CreateConnection() as IModel;

            var json = JsonSerializer.Serialize(message, message.GetType());

            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "sampleEntityQueue", body: body);
        }
    }
}

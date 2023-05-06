using System;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using CleanArchitectureCQRS.Shared.Producers;
using Microsoft.Extensions.Configuration;

namespace CleanArchitectureCQRS.Command.Infrastructure.Producers
{
    public class RabbitMQProducer : IMessageProducer
    {
        private readonly IConfiguration _configuration;

        public RabbitMQProducer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                HostName = _configuration.GetSection("RabbitMQ").GetChildren().First(x =>x.Key == "HostName").Value,
                UserName = _configuration.GetSection("RabbitMQ").GetChildren().First(x => x.Key == "UserName").Value,
                Password = _configuration.GetSection("RabbitMQ").GetChildren().First(x => x.Key == "Password").Value
            };

            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("sampleEntityQueue", exclusive: false);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "sampleEntityQueue", body: body);            
        }
    }
}

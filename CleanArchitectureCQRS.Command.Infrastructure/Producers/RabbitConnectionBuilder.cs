using System;
using CleanArchitectureCQRS.Shared.Rabbit;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace CleanArchitectureCQRS.Command.Infrastructure.Producers
{
    public class RabbitConnectionBuilder : IRabbitConnectionBuilder
    {
        private static IModel? model;
        private readonly IConfiguration _configuration;

        public RabbitConnectionBuilder(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public object CreateConnection()
        {
            if (model == null || !model.IsOpen)
            {
                var factory = new ConnectionFactory
                {
                    HostName = _configuration.GetSection("RabbitMQ").GetChildren().First(x => x.Key == "HostName").Value,
                    UserName = _configuration.GetSection("RabbitMQ").GetChildren().First(x => x.Key == "UserName").Value,
                    Password = _configuration.GetSection("RabbitMQ").GetChildren().First(x => x.Key == "Password").Value,
                    //AutomaticRecoveryEnabled = true
                };

                var connection = factory.CreateConnection();
                var channel = connection.CreateModel();

                channel.QueueDeclare("sampleEntityQueue", exclusive: false);
                model = channel;
            }
            return model;
        }
    }
}


using System;
namespace CleanArchitectureCQRS.Shared.Rabbit
{
    public interface IRabbitConnectionBuilder
    {
        object CreateConnection();
    }
}


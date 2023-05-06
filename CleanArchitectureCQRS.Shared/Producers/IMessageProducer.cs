using System;
namespace CleanArchitectureCQRS.Shared.Producers
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}


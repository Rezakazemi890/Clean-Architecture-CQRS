using System;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CleanArchitectureCQRS.Shared.Consumers
{
    public interface IMessageConsumer
    {
        void Consume();
    }
}


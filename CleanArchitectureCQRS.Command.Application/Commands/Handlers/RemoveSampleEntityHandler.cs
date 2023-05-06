using CleanArchitectureCQRS.Command.Application.Exceptions;
using CleanArchitectureCQRS.Domain.Repositories;
using CleanArchitectureCQRS.Shared.Abstractions.Commands;
using CleanArchitectureCQRS.Shared.Commands.CommandTypes;
using CleanArchitectureCQRS.Shared.Producers;

namespace CleanArchitectureCQRS.Command.Application.Commands.Handlers;

internal sealed class RemoveSampleEntityHandler : ICommandHandler<RemoveSampleEntity>
{
    private readonly IMessageProducer _messageProducer;

    public RemoveSampleEntityHandler(IMessageProducer messageProducer)
        => _messageProducer = messageProducer;

    public async Task HandleAsync(RemoveSampleEntity command)
    {
        _messageProducer.SendMessage(command);

        await Task.CompletedTask;
    }
}
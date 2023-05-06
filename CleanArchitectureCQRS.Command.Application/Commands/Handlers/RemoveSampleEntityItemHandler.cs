using CleanArchitectureCQRS.Command.Application.Exceptions;
using CleanArchitectureCQRS.Domain.Repositories;
using CleanArchitectureCQRS.Shared.Abstractions.Commands;
using CleanArchitectureCQRS.Shared.Commands.CommandTypes;
using CleanArchitectureCQRS.Shared.Producers;

namespace CleanArchitectureCQRS.Command.Application.Commands.Handlers;

internal sealed class RemoveSampleEntityItemHandler : ICommandHandler<RemoveSampleEntityItem>
{
    private readonly IMessageProducer _messageProducer;

    public RemoveSampleEntityItemHandler(IMessageProducer messageProducer)
        => _messageProducer = messageProducer;

    public async Task HandleAsync(RemoveSampleEntityItem command)
    {
        _messageProducer.SendMessage(command);

        await Task.CompletedTask;
    }
}


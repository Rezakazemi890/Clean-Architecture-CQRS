using CleanArchitectureCQRS.Command.Application.Exceptions;
using CleanArchitectureCQRS.Domain.Repositories;
using CleanArchitectureCQRS.Domain.ValueObjects;
using CleanArchitectureCQRS.Shared.Abstractions.Commands;
using CleanArchitectureCQRS.Shared.Commands.CommandTypes;
using CleanArchitectureCQRS.Shared.Producers;

namespace CleanArchitectureCQRS.Command.Application.Commands.Handlers;

internal sealed class AddSampleEntityItemHandler : ICommandHandler<AddSampleEntityItem>
{
    private readonly IMessageProducer _messageProducer;

    public AddSampleEntityItemHandler(IMessageProducer messageProducer)
        => _messageProducer = messageProducer;

    public async Task HandleAsync(AddSampleEntityItem command)
    {
        _messageProducer.SendMessage(command);

        await Task.CompletedTask;
    }
}


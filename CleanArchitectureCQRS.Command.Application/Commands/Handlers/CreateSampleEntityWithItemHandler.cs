using CleanArchitectureCQRS.Command.Application.Exceptions;
using CleanArchitectureCQRS.Shared.Services;
using CleanArchitectureCQRS.Domain.Factories;
using CleanArchitectureCQRS.Domain.Repositories;
using CleanArchitectureCQRS.Domain.ValueObjects;
using CleanArchitectureCQRS.Shared.Abstractions.Commands;
using CleanArchitectureCQRS.Shared.Commands.CommandTypes;
using CleanArchitectureCQRS.Shared.Producers;

namespace CleanArchitectureCQRS.Command.Application.Commands.Handlers;

public class CreateSampleEntityWithItemHandler : ICommandHandler<CreateSampleEntityWithItems>
{
    private readonly IMessageProducer _messageProducer;

    public CreateSampleEntityWithItemHandler(IMessageProducer messageProducer)
        => _messageProducer = messageProducer;

    public async Task HandleAsync(CreateSampleEntityWithItems command)
    {
        _messageProducer.SendMessage(command);

        await Task.CompletedTask;
    }
}


using CleanArchitectureCQRS.Query.Application.Exceptions;
using CleanArchitectureCQRS.Domain.Repositories;
using CleanArchitectureCQRS.Domain.ValueObjects;
using CleanArchitectureCQRS.Shared.Abstractions.Commands;
using CleanArchitectureCQRS.Shared.Commands.CommandTypes;
using CleanArchitectureCQRS.Shared.Producers;

namespace CleanArchitectureCQRS.Query.Infrastructure.EF.Commands.Handlers;

internal sealed class AddSampleEntityItemHandler : ICommandHandler<AddSampleEntityItem>
{
    private readonly ISampleEntityRepository _repository;

    public AddSampleEntityItemHandler(ISampleEntityRepository repository)
        => _repository = repository;

    public async Task HandleAsync(AddSampleEntityItem command)
    {
        var sampleEntity = await _repository.GetAsyncById(command.sampleEntityId);

        if (sampleEntity is null)
        {
            throw new SampleEntityNotFound(command.sampleEntityId);
        }

        var sampleEntityItem = new SampleEntityItem(command.Name, command.Quantity);
        sampleEntity.AddItem(sampleEntityItem);

        await _repository.UpdateAsync(sampleEntity);
    }
}


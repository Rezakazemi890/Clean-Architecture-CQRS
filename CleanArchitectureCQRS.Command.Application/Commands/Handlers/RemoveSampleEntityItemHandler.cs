using CleanArchitectureCQRS.Command.Application.Exceptions;
using CleanArchitectureCQRS.Domain.Repositories;
using CleanArchitectureCQRS.Shared.Abstractions.Commands;
using CleanArchitectureCQRS.Shared.Commands.CommandTypes;

namespace CleanArchitectureCQRS.Command.Application.Commands.Handlers;

internal sealed class RemoveSampleEntityItemHandler : ICommandHandler<RemoveSampleEntityItem>
{
    private readonly ISampleEntityRepository _repository;

    public RemoveSampleEntityItemHandler(ISampleEntityRepository repository)
        => _repository = repository;

    public async Task HandleAsync(RemoveSampleEntityItem command)
    {
        var sampleEntity = await _repository.GetAsyncById(command.sampleEntityId);

        if (sampleEntity is null)
        {
            throw new SampleEntityNotFound(command.sampleEntityId);
        }

        sampleEntity.RemoveItem(command.Name);

        await _repository.UpdateAsync(sampleEntity);
    }
}


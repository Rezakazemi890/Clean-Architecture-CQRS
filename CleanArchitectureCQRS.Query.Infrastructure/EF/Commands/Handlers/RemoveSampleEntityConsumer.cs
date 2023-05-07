using CleanArchitectureCQRS.Query.Application.Exceptions;
using CleanArchitectureCQRS.Domain.Repositories;
using CleanArchitectureCQRS.Shared.Abstractions.Commands;
using CleanArchitectureCQRS.Shared.Commands.CommandTypes;

namespace CleanArchitectureCQRS.Query.Infrastructure.EF.Commands.Handlers;

internal sealed class RemoveSampleEntityConsumer : IConsumeHandler<RemoveSampleEntity>
{
    private readonly ISampleEntityRepository _repository;

    public RemoveSampleEntityConsumer(ISampleEntityRepository repository)
        => _repository = repository;

    public async Task HandleAsync(RemoveSampleEntity command)
    {
        var sampleEntity = await _repository.GetAsyncById(command.Id);

        if (sampleEntity is null)
        {
            throw new SampleEntityNotFound(command.Id);
        }

        await _repository.DeleteAsync(sampleEntity);
    }
}
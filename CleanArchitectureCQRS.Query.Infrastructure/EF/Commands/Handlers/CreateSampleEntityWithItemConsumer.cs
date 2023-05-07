using CleanArchitectureCQRS.Query.Application.Exceptions;
using CleanArchitectureCQRS.Shared.Services;
using CleanArchitectureCQRS.Domain.Factories;
using CleanArchitectureCQRS.Domain.Repositories;
using CleanArchitectureCQRS.Domain.ValueObjects;
using CleanArchitectureCQRS.Shared.Abstractions.Commands;
using CleanArchitectureCQRS.Shared.Commands.CommandTypes;

namespace CleanArchitectureCQRS.Query.Infrastructure.EF.Commands.Handlers;

public class CreateSampleEntityWithItemConsumer : IConsumeHandler<CreateSampleEntityWithItems>
{
    private readonly ISampleEntityRepository _repository;
    private readonly ISampleEntityFactory _factory;
    private readonly ISampleEntityReadService _readService;

    public CreateSampleEntityWithItemConsumer(ISampleEntityRepository repository, ISampleEntityFactory factory,
        ISampleEntityReadService readService)
    {
        _repository = repository;
        _factory = factory;
        _readService = readService;
    }

    public async Task HandleAsync(CreateSampleEntityWithItems command)
    {
        var (id, name, gender, DestinationWriteModel) = command;


        if (await _readService.ExistsByNameAsync(name))
        {
            throw new SampleEntityAlreadyExistsException(name);
        }


        var destination = new SampleEntityDestination(DestinationWriteModel.City, DestinationWriteModel.Country);

        var sampleEntity = _factory.CreateWithDefaultItems(id, name, gender,
            destination);

        await _repository.AddAsync(sampleEntity);
    }

}


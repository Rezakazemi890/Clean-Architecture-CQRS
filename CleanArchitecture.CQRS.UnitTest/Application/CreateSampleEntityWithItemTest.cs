using CleanArchitectureCQRS.Application.Commands;
using CleanArchitectureCQRS.Application.Commands.Handlers;
using CleanArchitectureCQRS.Application.Exceptions;
using CleanArchitectureCQRS.Application.Services;
using CleanArchitectureCQRS.Domain.Consts;
using CleanArchitectureCQRS.Domain.Entities;
using CleanArchitectureCQRS.Domain.Factories;
using CleanArchitectureCQRS.Domain.Repositories;
using CleanArchitectureCQRS.Domain.ValueObjects;
using CleanArchitectureCQRS.Shared.Abstractions.Commands;
using NSubstitute;
using Shouldly;

namespace CleanArchitecture.CQRS.UnitTest.Application;

public class CreateSampleEntityWithItemTest
{
    Task Act(CreateSampleEntityWithItems command)
    => _commandHandler.HandleAsync(command);

    [Fact]
    public async Task HandleAsync_Throws_SampleEntityAlreadyExistsException_When_List_With_same_Name_Already_Exists()
    {
        var command = new CreateSampleEntityWithItems(Guid.NewGuid(), "MyList", Gender.Female, default);
        _readService.ExistsByNameAsync(command.Name).Returns(true);

        var exception = await Record.ExceptionAsync(() => Act(command));

        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<SampleEntityAlreadyExistsException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_Repository_On_Success()
    {
        var command = new CreateSampleEntityWithItems(Guid.NewGuid(), "MyList", Gender.Female,
            new DestinationWriteModel("ESF", "Iran"));

        _readService.ExistsByNameAsync(command.Name).Returns(false);
        _factory.CreateWithDefaultItems(command.Id, command.Name, command.Gender,
            Arg.Any<SampleEntityDestination>()).Returns(default(SampleEntity));

        var exception = await Record.ExceptionAsync(() => Act(command));

        exception.ShouldBeNull();
        await _repository.Received(1).AddAsync(Arg.Any<SampleEntity>());
    }

    #region ARRANGE

    private readonly ICommandHandler<CreateSampleEntityWithItems> _commandHandler;
    private readonly ISampleEntityRepository _repository;
    private readonly ISampleEntityReadService _readService;
    private readonly ISampleEntityFactory _factory;

    public CreateSampleEntityWithItemTest()
    {
        _repository = Substitute.For<ISampleEntityRepository>();
        _readService = Substitute.For<ISampleEntityReadService>();
        _factory = Substitute.For<ISampleEntityFactory>();
        _commandHandler = new CreateSampleEntityWithItemHandler(_repository, _factory, _readService);
    }

    #endregion
}

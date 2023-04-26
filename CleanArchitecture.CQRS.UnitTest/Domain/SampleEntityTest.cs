using CleanArchitectureCQRS.Application.Exceptions;
using CleanArchitectureCQRS.Domain.Entities;
using CleanArchitectureCQRS.Domain.Events;
using CleanArchitectureCQRS.Domain.Exceptions;
using CleanArchitectureCQRS.Domain.Factories;
using CleanArchitectureCQRS.Domain.Policies;
using CleanArchitectureCQRS.Domain.ValueObjects;
using Shouldly;

namespace CleanArchitecture.CQRS.UnitTest.Domain;

public class SampleEntityTest
{
    [Fact]
    public void AddItem_Throws_SampleEntityItemAlreadyExistsException_When_There_Is_Already_Item_With_The_Same_Name()
    {
        //ARRANGE
        var sampleEntity = GetSampleEntity();
        sampleEntity.AddItem(new SampleEntityItem("Item 1", 1));

        //ACT
        var exception = Record.Exception(() => sampleEntity.AddItem(new SampleEntityItem("Item 1", 1)));

        //ASSERT
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<SampleDuplicateException>();
    }

    [Fact]
    public void AddItem_Adds_SampleEntityItemAdded_Domain_Event_On_Success()
    {
        var sampleEntity = GetSampleEntity();

        var exception = Record.Exception(() => sampleEntity.AddItem(new SampleEntityItem("Item 1", 1)));

        exception.ShouldBeNull();
        sampleEntity.Events.Count().ShouldBe(1);

        var @event = sampleEntity.Events.FirstOrDefault() as SampleEntityItemAdded;

        @event.ShouldNotBeNull();
        @event.sampleEntityItem.Name.ShouldBe("Item 1");
    }


    #region ARRANGE

    private SampleEntity GetSampleEntity()
    {
        var sampleEntity = _factory.Create(Guid.NewGuid(), "MyEntity", SampleEntityDestination.Create("Shiraz, Iran"));
        sampleEntity.ClearEvents();
        return sampleEntity;
    }

    private readonly ISampleEntityFactory _factory;

    public SampleEntityTest()
    {
        _factory = new SampleEntityFactory(Enumerable.Empty<ISampleEntityItemsPolicy>());
    }

    #endregion

}

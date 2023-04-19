using CleanArchitectureCQRS.Domain.Consts;
using CleanArchitectureCQRS.Domain.Entities;
using CleanArchitectureCQRS.Domain.ValueObjects;

namespace CleanArchitectureCQRS.Domain.Factories;

    public interface ISampleEntityFactory
    {
        SampleEntity Create(SampleEntityId id, SampleEntityName name, SampleEntityDestination destination);

        SampleEntity CreateWithDefaultItems(SampleEntityId id, SampleEntityName name, Gender gender,
            SampleEntityDestination destination);
    }

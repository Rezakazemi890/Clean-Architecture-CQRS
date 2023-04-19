
namespace CleanArchitectureCQRS.Domain.Events;

public record SampleEntityItemAdded(SampleEntity sampleEntity, SampleEntityItem sampleEntityItem) : IDomainEvent;

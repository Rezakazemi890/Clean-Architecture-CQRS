namespace CleanArchitectureCQRS.Domain.Events;

public record SampleEntityItemRemoved(SampleEntity sampleEntity, sampleEntityItem sampleEntity) : IDomainEvent;
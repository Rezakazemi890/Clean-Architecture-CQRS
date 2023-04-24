using CleanArchitectureCQRS.Shared.Abstractions.Commands;

namespace CleanArchitectureCQRS.Application.Commands;

public record RemoveSampleEntityItem(Guid sampleEntityId, string Name) : ICommand;

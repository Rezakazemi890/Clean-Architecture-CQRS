using CleanArchitectureCQRS.Shared.Abstractions.Commands;

namespace CleanArchitectureCQRS.Shared.Commands.CommandTypes;

public record RemoveSampleEntityItem(Guid sampleEntityId, string Name) : ICommand;

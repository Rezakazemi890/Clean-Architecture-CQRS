using CleanArchitectureCQRS.Shared.Abstractions.Commands;

namespace CleanArchitectureCQRS.Shared.Commands.CommandTypes;

public record TakeItem(Guid sampleEntityId, string Name) : ICommand;
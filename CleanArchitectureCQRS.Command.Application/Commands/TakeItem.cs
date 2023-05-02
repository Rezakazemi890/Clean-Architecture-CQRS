using CleanArchitectureCQRS.Shared.Abstractions.Commands;

namespace CleanArchitectureCQRS.Command.Application.Commands;

public record TakeItem(Guid sampleEntityId, string Name) : ICommand;
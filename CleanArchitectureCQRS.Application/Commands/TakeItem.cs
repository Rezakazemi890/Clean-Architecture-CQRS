using CleanArchitectureCQRS.Shared.Abstractions.Commands;

namespace CleanArchitectureCQRS.Application.Commands;

public record TakeItem(Guid sampleEntityId, string Name) : ICommand;
using CleanArchitectureCQRS.Shared.Abstractions.Commands;

namespace CleanArchitectureCQRS.Application.Commands.Handlers;

public record AddSampleEntityItem(Guid sampleEntityId, string Name, uint Quantity) : ICommand;

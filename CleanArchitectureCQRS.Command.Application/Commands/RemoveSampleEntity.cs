using CleanArchitectureCQRS.Shared.Abstractions.Commands;

namespace CleanArchitectureCQRS.Command.Application.Commands;

public record RemoveSampleEntity(Guid Id) : ICommand;

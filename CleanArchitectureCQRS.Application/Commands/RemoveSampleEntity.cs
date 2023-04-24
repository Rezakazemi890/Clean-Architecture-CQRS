using CleanArchitectureCQRS.Shared.Abstractions.Commands;

namespace CleanArchitectureCQRS.Application.Commands;

public record RemoveSampleEntity(Guid Id) : ICommand;

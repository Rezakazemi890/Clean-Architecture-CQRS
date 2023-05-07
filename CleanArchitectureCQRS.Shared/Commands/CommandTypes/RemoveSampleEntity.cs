using CleanArchitectureCQRS.Shared.Abstractions.Commands;

namespace CleanArchitectureCQRS.Shared.Commands.CommandTypes;

public record RemoveSampleEntity(Guid Id) : ICommand
{
    public string Type { get { return this.GetType().Name; } }
}

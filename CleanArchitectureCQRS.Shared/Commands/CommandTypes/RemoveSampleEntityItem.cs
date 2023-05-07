using CleanArchitectureCQRS.Shared.Abstractions.Commands;

namespace CleanArchitectureCQRS.Shared.Commands.CommandTypes;

public record RemoveSampleEntityItem(Guid sampleEntityId, string Name) : ICommand
{
    public string Type { get { return this.GetType().Name; } }
}


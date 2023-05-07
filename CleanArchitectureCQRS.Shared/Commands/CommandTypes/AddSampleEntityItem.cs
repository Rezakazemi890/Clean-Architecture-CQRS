using CleanArchitectureCQRS.Shared.Abstractions.Commands;

namespace CleanArchitectureCQRS.Shared.Commands.CommandTypes;

public record AddSampleEntityItem(Guid sampleEntityId, string Name, uint Quantity) : ICommand
{
    public string Type { get { return this.GetType().Name; }}
}

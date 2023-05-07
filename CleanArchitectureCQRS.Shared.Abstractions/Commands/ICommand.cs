namespace CleanArchitectureCQRS.Shared.Abstractions.Commands;

public interface ICommand
{
    string Type { get; }
}

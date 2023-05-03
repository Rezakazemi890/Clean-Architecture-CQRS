using CleanArchitectureCQRS.Domain.Consts;
using CleanArchitectureCQRS.Shared.Abstractions.Commands;

namespace CleanArchitectureCQRS.Shared.Commands.CommandTypes;

public record CreateSampleEntityWithItems(Guid Id, string Name, Gender Gender,
   DestinationWriteModel Destionation) : ICommand;

public record DestinationWriteModel(string City, string Country);

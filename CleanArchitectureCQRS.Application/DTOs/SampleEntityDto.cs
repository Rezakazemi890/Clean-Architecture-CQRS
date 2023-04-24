namespace CleanArchitectureCQRS.Application.DTOs;

public record SampleEntityDto(Guid Id,
                              string Name,
                              DestinationDto Destination,
                              IEnumerable<SampleEntityItemDto> Items);

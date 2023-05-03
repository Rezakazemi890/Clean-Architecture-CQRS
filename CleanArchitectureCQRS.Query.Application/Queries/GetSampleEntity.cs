using CleanArchitectureCQRS.Query.Application.DTOs;
using CleanArchitectureCQRS.Shared.Abstractions.Queries;

namespace CleanArchitectureCQRS.Query.Application.Queries;

public class GetSampleEntity : IQuery<SampleEntityDto>
{
    public Guid Id { get; set; }
}

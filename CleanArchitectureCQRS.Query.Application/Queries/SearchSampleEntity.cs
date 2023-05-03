using CleanArchitectureCQRS.Query.Application.DTOs;
using CleanArchitectureCQRS.Shared.Abstractions.Queries;

namespace CleanArchitectureCQRS.Query.Application.Queries;

public class SearchSampleEntity : IQuery<IEnumerable<SampleEntityDto>>
{
    public string SearchPhrase { get; set; }
}

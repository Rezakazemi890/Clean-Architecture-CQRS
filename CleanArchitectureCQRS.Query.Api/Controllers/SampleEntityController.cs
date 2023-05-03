using CleanArchitectureCQRS.Query.Application.DTOs;
using CleanArchitectureCQRS.Query.Application.Queries;
using CleanArchitectureCQRS.Shared.Abstractions.Commands;
using CleanArchitectureCQRS.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureCQRS.Query.Api.Controllers;

public class SampleEntityController : BaseController
{
    private readonly IQueryDispatcher _queryDispatcher;

    public SampleEntityController(IQueryDispatcher queryDispatcher)
    {
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SampleEntityDto>> Get([FromRoute] GetSampleEntity query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SampleEntityDto>>> Get([FromQuery] SearchSampleEntity query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }
}

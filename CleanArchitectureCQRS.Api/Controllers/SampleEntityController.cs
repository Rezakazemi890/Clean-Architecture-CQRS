using CleanArchitectureCQRS.Application.Commands;
using CleanArchitectureCQRS.Application.Commands.Handlers;
using CleanArchitectureCQRS.Application.DTOs;
using CleanArchitectureCQRS.Application.Queries;
using CleanArchitectureCQRS.Shared.Abstractions.Commands;
using CleanArchitectureCQRS.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureCQRS.Api.Controllers;

public class SampleEntityController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public SampleEntityController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
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

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateSampleEntityWithItems command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
    }

    [HttpPut("{SampleEntityId}/items")]
    public async Task<IActionResult> Put([FromBody] AddSampleEntityItem command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }

    [HttpPut("{SampleEntityId:guid}/items/{name}/Take")]
    public async Task<IActionResult> Put([FromBody] TakeItem command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }

    [HttpDelete("{SampleEntityId:guid}/items/{name}")]
    public async Task<IActionResult> Delete([FromBody] RemoveSampleEntityItem command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromBody] RemoveSampleEntity command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }
}

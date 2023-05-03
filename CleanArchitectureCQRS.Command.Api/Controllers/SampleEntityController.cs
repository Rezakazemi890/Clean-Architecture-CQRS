using CleanArchitectureCQRS.Shared.Abstractions.Commands;
using CleanArchitectureCQRS.Shared.Commands.CommandTypes;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureCQRS.Command.Api.Controllers;

public class SampleEntityController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;

    public SampleEntityController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateSampleEntityWithItems command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
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

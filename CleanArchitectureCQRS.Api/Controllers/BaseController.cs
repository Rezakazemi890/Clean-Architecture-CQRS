using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureCQRS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
//UnMark if you need : 
//[Consumes("application/json")]
//[Produces("application/json")]
//[EnableCors("AllowAll")]
public abstract class BaseController : ControllerBase
{
    protected ActionResult<TResult> OkOrNotFound<TResult>(TResult result)
        => result is null ? NotFound() : Ok(result);
}
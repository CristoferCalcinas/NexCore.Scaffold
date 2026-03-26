using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace NexCore.Presentation.Common;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiController : ControllerBase
{
    protected IActionResult OkOrBadRequest<T>(Result<T> result, string? successMessage = null)
    {
        var response = result.ToApiResponse(successMessage);
        return result.IsSuccess ? Ok(response) : BadRequest(response);
    }

    protected IActionResult OkOrBadRequest(Result result, string? successMessage = null)
    {
        var response = result.ToApiResponse(successMessage);
        return result.IsSuccess ? Ok(response) : BadRequest(response);
    }

    protected IActionResult CreatedOrBadRequest<T>(Result<T> result, string actionName, object routeValues, string? successMessage = null)
    {
        if (result.IsFailed)
            return BadRequest(result.ToApiResponse());

        return CreatedAtAction(actionName, routeValues, result.ToApiResponse(successMessage ?? "Recurso creado exitosamente."));
    }

    protected IActionResult NotFoundOrOk<T>(Result<T> result, string? successMessage = null)
    {
        if (result.IsFailed)
            return NotFound(result.ToApiResponse());

        return Ok(result.ToApiResponse(successMessage));
    }
}

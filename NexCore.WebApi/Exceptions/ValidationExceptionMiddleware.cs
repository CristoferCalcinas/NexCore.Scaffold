using FluentValidation;
using NexCore.Presentation.Common;
using System.Text.Json;

namespace NexCore.WebApi.Exceptions;

public sealed class ValidationExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors
                .Select(e => e.ErrorMessage)
                .ToList();

            var response = new ApiResponse<object>
            {
                Message = "Operacion fallida.",
                Errors = errors
            };

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response, JsonSerializerOptions.Web),
                context.RequestAborted
            );
        }
    }
}
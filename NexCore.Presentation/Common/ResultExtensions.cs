using FluentResults;

namespace NexCore.Presentation.Common;

public static class ResultExtensions
{
    public static ApiResponse<T> ToApiResponse<T>(this Result<T> result, string? successMessage = null)
    {
        return new ApiResponse<T>
        {
            Data = result.IsSuccess ? result.Value : default,
            Message = result.IsSuccess
                ? (successMessage ?? "Operacion realizada con exito.")
                : "Operacion fallida.",
            Errors = result.Errors.Select(e => e.Message)
        };
    }

    public static ApiResponse<object> ToApiResponse(this Result result, string? successMessage = null)
    {
        return new ApiResponse<object>
        {
            Message = result.IsSuccess
                ? (successMessage ?? "Operacion realizada con exito.")
                : "Operacion fallida.",
            Errors = result.Errors.Select(e => e.Message)
        };
    }
}

namespace NexCore.Presentation.Common;

public class ApiResponse<T>
{
    public T? Data { get; init; }
    public string Message { get; init; } = string.Empty;
    public IEnumerable<string> Errors { get; init; } = [];
}

namespace TennisScoreApi.Common;

public class ApiResponse<T>
{
    // Indicates whether operation succeeded
    public bool Success { get; set; }

    // User-friendly message
    public string Message { get; set; } = string.Empty;

    // Actual response payload
    public T? Data { get; set; }
}
namespace TennisScoreApi.DTOs.Responses;

/// <summary>
/// Standard API error response.
/// </summary>
public class ErrorResponse
{
    public bool Success { get; set; }

    public string Message { get; set; }
        = string.Empty;
}
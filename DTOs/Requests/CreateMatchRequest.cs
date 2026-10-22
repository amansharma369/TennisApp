namespace TennisScoreApi.DTOs.Requests;

/// <summary>
/// Request used to create a new tennis match.
/// </summary>
public class CreateMatchRequest
{
    /// <summary>
    /// Name of the first player.
    /// </summary>
    public string Player1Name { get; set; } = string.Empty;

    /// <summary>
    /// Name of the second player.
    /// </summary>
    public string Player2Name { get; set; } = string.Empty;
}
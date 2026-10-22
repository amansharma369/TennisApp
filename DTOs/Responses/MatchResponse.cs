namespace TennisScoreApi.DTOs.Responses;

/// <summary>
/// Response returned after creating or fetching a match.
/// </summary>
public class MatchResponse
{
    public int MatchId { get; set; }

    public string Player1Name { get; set; } = string.Empty;

    public string Player2Name { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;
}
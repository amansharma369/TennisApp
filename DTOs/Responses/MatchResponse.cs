// Namespace for response DTOs
namespace TennisScoreApi.DTOs.Responses;

public class MatchResponse
{
    // Match identifier returned to client
    public int MatchId { get; set; }

    // First player name
    public string Player1 { get; set; } = string.Empty;

    // Second player name
    public string Player2 { get; set; } = string.Empty;

    // Match status
    public string Status { get; set; } = string.Empty;
}
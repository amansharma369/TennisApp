namespace TennisScoreApi.Models;

public class Match
{
    // Primary Key
    public int MatchId { get; set; }

    // First player name
    public string Player1 { get; set; } = string.Empty;

    // Second player name
    public string Player2 { get; set; } = string.Empty;

    // Match status
    public string Status { get; set; } = string.Empty;
}
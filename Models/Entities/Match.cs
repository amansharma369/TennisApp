using TennisScoreApi.Models.Enums;

namespace TennisScoreApi.Models.Entities;

/// <summary>
/// Represents a tennis match between two players.
/// A match contains sets, tracks status,
/// current server and determines the overall winner.
/// </summary>
public class Match
{
    /// <summary>
    /// Unique identifier of the match.
    /// </summary>
    public int MatchId { get; private set; }

    /// <summary>
    /// First player participating in the match.
    /// </summary>
    public Player Player1 { get; private set; }

    /// <summary>
    /// Second player participating in the match.
    /// </summary>
    public Player Player2 { get; private set; }

    /// <summary>
    /// Collection of sets played in this match.
    /// </summary>
    public List<Set> Sets { get; private set; }

    /// <summary>
    /// Player currently serving.
    /// </summary>
    public Player CurrentServer { get; private set; }

    /// <summary>
    /// Current status of the match.
    /// </summary>
    public MatchStatus Status { get; private set; }

    /// <summary>
    /// Winner of the match.
    /// Null until determined.
    /// </summary>
    public Player? Winner { get; private set; }

    /// <summary>
    /// Creates a valid tennis match.
    /// </summary>
    public Match(
        int matchId,
        Player player1,
        Player player2,
        Player firstServer)
    {
        MatchId = matchId;
        Player1 = player1;
        Player2 = player2;

        CurrentServer = firstServer;

        Sets = new List<Set>();

        Status = MatchStatus.Scheduled;
    }

    /// <summary>
    /// Starts the match.
    /// </summary>
    public void StartMatch()
    {
        Status = MatchStatus.InProgress;
    }


    /// <summary>
    /// Adds a completed set to the match.
    /// </summary>
    public void AddSet(Set set)
    {
        Sets.Add(set);
    }

    /// <summary>
    /// Ends the match and assigns the winner.
    /// </summary>
    public void EndMatch(Player winner)
    {
        Winner = winner;
        Status = MatchStatus.Completed;
    }
}
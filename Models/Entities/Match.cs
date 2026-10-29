using TennisScoreApi.Models.Enums;

namespace TennisScoreApi.Models.Entities;

/// <summary>
/// Represents a tennis match between two players.
/// A match contains sets, tracks match status,
/// and determines the overall winner.
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
    /// Null until a winner has been determined.
    /// </summary>
    public Player? Winner { get; private set; }

    /// <summary>
    /// Number of sets won by Player 1.
    /// </summary>
    public int Player1SetsWon { get; private set; }

    /// <summary>
    /// Number of sets won by Player 2.
    /// </summary>
    public int Player2SetsWon { get; private set; }

    /// <summary>
    /// Creates a valid tennis match.
    /// A match cannot exist without two players and an initial server.
    /// </summary>
    public Match(
    Player player1,
    Player player2,
    Player firstServer)
    {
        Player1 = player1;
        Player2 = player2;

        CurrentServer = firstServer;

        Player1SetsWon = 0;
        Player2SetsWon = 0;

        var firstSet =
            new Set(player1, player2);

        var firstGame =
            new Game(
                player1,
                player2,
                firstServer);

        firstSet.Games.Add(firstGame);

        Sets = new List<Set>
        {
            firstSet
        };

        Status = MatchStatus.Scheduled;
    }
    private Match()
    {
        Sets = new List<Set>();
    }

    /// <summary>
    /// Starts the match.
    /// </summary>
    public void StartMatch()
    {
        Status = MatchStatus.InProgress;
    }

    /// <summary>
    /// Adds a completed set to the match,
    /// updates set counts,
    /// and determines whether the match has a winner.
    /// </summary>
    public void AddSet(Set set)
    {
        Sets.Add(set);

        if (set.Winner == Player1)
        {
            Player1SetsWon++;
        }
        else if (set.Winner == Player2)
        {
            Player2SetsWon++;
        }

        CheckWinner();
    }

    /// <summary>
    /// Determines whether either player has won the match.
    /// Best-of-three format:
    /// the first player to win two sets wins the match.
    /// </summary>
    private void CheckWinner()
    {
        if (Player1SetsWon >= 2)
        {
            EndMatch(Player1);
        }

        if (Player2SetsWon >= 2)
        {
            EndMatch(Player2);
        }
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
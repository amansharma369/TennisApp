namespace TennisScoreApi.Models.Entities;

/// <summary>
/// Represents a tennis set.
/// A set contains multiple games and determines a set winner.
/// </summary>
public class Set
{
    /// <summary>
    /// Unique identifier of the set.
    /// </summary>
    public int SetId { get; private set; }

    /// <summary>
    /// Number of games won by Player 1.
    /// </summary>
    public int Player1GamesWon { get; private set; }

    /// <summary>
    /// Number of games won by Player 2.
    /// </summary>
    public int Player2GamesWon { get; private set; }

    /// <summary>
    /// Tie-break points won by Player 1.
    /// </summary>
    public int Player1TiebreakPoints { get; private set; }

    /// <summary>
    /// Tie-break points won by Player 2.
    /// </summary>
    public int Player2TiebreakPoints { get; private set; }

    /// <summary>
    /// Indicates whether the set is currently in tie-break mode.
    /// </summary>
    public bool IsTiebreak { get; private set; }

    /// <summary>
    /// Winner of the set.
    /// Null until a winner is determined.
    /// </summary>
    public Player? Winner { get; private set; }

    /// <summary>
    /// Collection of games played in this set.
    /// </summary>
    public List<Game> Games { get; private set; }

    /// <summary>
    /// Creates a new tennis set.
    /// </summary>
    public Set(int setId)
    {
        SetId = setId;

        Games = new List<Game>();

        Player1GamesWon = 0;
        Player2GamesWon = 0;

        Player1TiebreakPoints = 0;
        Player2TiebreakPoints = 0;

        IsTiebreak = false;
    }

    /// <summary>
    /// Adds a completed game to the set.
    /// </summary>
    public void AddGame(Game game)
    {
        Games.Add(game);
    }

    /// <summary>
    /// Starts tie-break mode.
    /// </summary>
    public void StartTiebreak()
    {
        IsTiebreak = true;
    }

    /// <summary>
    /// Checks whether a player has won the set.
    /// </summary>
    public void CheckWinner()
    {
        // To be implemented
    }

    /// <summary>
    /// Ends the set.
    /// </summary>
    public void EndSet()
    {
        // To be implemented
    }
}
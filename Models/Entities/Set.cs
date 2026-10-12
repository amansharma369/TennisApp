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
    /// First player participating in the set.
    /// </summary>
    public Player Player1 { get; private set; }

    /// <summary>
    /// Second player participating in the set.
    /// </summary>
    public Player Player2 { get; private set; }

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
    public Set(int setId, Player player1, Player player2)
    {
        SetId = setId;
        Player1 = player1;
        Player2 = player2;

        Games = new List<Game>();

        Player1GamesWon = 0;
        Player2GamesWon = 0;

        Player1TiebreakPoints = 0;
        Player2TiebreakPoints = 0;

        IsTiebreak = false;
    }

    /// <summary>
    /// Adds a completed game to the set,
    /// updates game counts,
    /// checks tie-break conditions,
    /// and determines if the set has a winner.
    /// </summary>
    public void AddGame(Game game)
    {
        Games.Add(game);

        if (game.Winner == Player1)
        {
            Player1GamesWon++;
        }
        else if (game.Winner == Player2)
        {
            Player2GamesWon++;
        }

        CheckTieBreak();
        CheckWinner();
    }

    /// <summary>
    /// Checks whether the set should enter tie-break mode.
    /// </summary>
    private void CheckTieBreak()
    {
        if (Player1GamesWon == 6 &&
            Player2GamesWon == 6)
        {
            StartTiebreak();
        }
    }

    /// <summary>
    /// Starts tie-break mode.
    /// </summary>
    public void StartTiebreak()
    {
        
    }

    /// <summary>
    /// Awards a tie-break point to the specified player
    /// and checks if the tie-break has been won.
    /// </summary>
    public void AwardTieBreakPoint(Player winner)
    {
        if (!IsTiebreak)
        {
            throw new InvalidOperationException(
                "Tie-break has not started.");
        }

        if (winner == Player1)
        {
            Player1TiebreakPoints++;
        }
        else if (winner == Player2)
        {
            Player2TiebreakPoints++;
        }

        CheckTieBreakWinner();
    }

    /// <summary>
    /// Determines whether either player has won the tie-break.
    /// A player must reach at least 7 points
    /// and lead by 2 points.
    /// </summary>
    private void CheckTieBreakWinner()
    {
        if (Player1TiebreakPoints >= 7 &&
            Player1TiebreakPoints - Player2TiebreakPoints >= 2)
        {
            Winner = Player1;
            EndSet();
        }

        if (Player2TiebreakPoints >= 7 &&
            Player2TiebreakPoints - Player1TiebreakPoints >= 2)
        {
            Winner = Player2;
            EndSet();
        }
    }

    /// <summary>
    /// Determines whether either player has won the set.
    /// A player must win at least 6 games and lead by 2 games.
    /// </summary>
    private void CheckWinner()
    {
        if (Player1GamesWon >= 6 &&
            Player1GamesWon - Player2GamesWon >= 2)
        {
            Winner = Player1;
        }

        if (Player2GamesWon >= 6 &&
            Player2GamesWon - Player1GamesWon >= 2)
        {
            Winner = Player2;
        }
    }

    /// <summary>
    /// Ends the set.
    /// Future set-completion actions will be added here.
    /// </summary>
    public void EndSet()
    {
        IsTiebreak = false;
    }
}
using TennisScoreApi.Models.Enums;

namespace TennisScoreApi.Models.Entities;

/// <summary>
/// Represents a single tennis game within a set.
/// A game tracks points, deuce, advantage, server and winner.
/// </summary>
public class Game
{
    /// <summary>
    /// Unique identifier of the game.
    /// </summary>
    public int GameId { get; private set; }

    /// <summary>
    /// First player participating in the game.
    /// </summary>
    public Player Player1 { get; private set; }

    /// <summary>
    /// Second player participating in the game.
    /// </summary>
    public Player Player2 { get; private set; }

    /// <summary>
    /// Player serving this game.
    /// </summary>
    public Player Server { get; private set; }

    /// <summary>
    /// Winner of the game.
    /// Null until the game has been completed.
    /// </summary>
    public Player? Winner { get; private set; }

    /// <summary>
    /// Points won by player 1 in this game.
    /// Stored as raw point count, not tennis-display score.
    /// </summary>
    public int Player1Points { get; private set; }

    /// <summary>
    /// Points won by player 2 in this game.
    /// Stored as raw point count, not tennis-display score.
    /// </summary>
    public int Player2Points { get; private set; }

    /// <summary>
    /// Indicates whether the game is currently in deuce.
    /// </summary>
    public bool IsDeuce { get; private set; }

    /// <summary>
    /// Player currently holding advantage.
    /// Null when there is no advantage.
    /// </summary>
    public Player? AdvantagePlayer { get; private set; }

    /// <summary>
    /// Collection of all points played in this game.
    /// </summary>
    public List<Point> Points { get; private set; }

    /// <summary>
    /// Creates a new game with a server.
    /// </summary>
    public Game(int gameId, Player player1, Player player2, Player server)
    {
        GameId = gameId;
        Player1 = player1;
        Player2 = player2;
        Server = server;

        Points = new List<Point>();

        Player1Points = 0;
        Player2Points = 0;

        IsDeuce = false;
        AdvantagePlayer = null;
    }

    private Game()
    {
        Points = new List<Point>();
    }

    /// <summary>
    /// Awards a point and records it in the game.
    /// </summary>
    public void AwardPoint(Point point)
    {
        Points.Add(point);
        UpdateStatistics(point);

        if (point.Winner == Player1)    
        {
            Player1Points++;
        }
        else if (point.Winner == Player2)
        {
            Player2Points++;
        }
        CheckDeuce();
        CheckAdvantage();
        CheckWinner();
    }
    
    /// <summary>
    /// Updates player statistics based on the point outcome.
    /// </summary>
    private void UpdateStatistics(Point point)
    {
        switch (point.Outcome)
        {
            case PointOutcome.Ace:
                point.Winner.RecordAce();
                break;

            case PointOutcome.ServiceWinner:
                point.Winner.RecordServiceWinner();
                break;

            case PointOutcome.Winner:
                point.Winner.RecordWinner();
                break;

            case PointOutcome.ForcedError:
                point.Winner.RecordForcedError();
                break;

            case PointOutcome.UnforcedError:
                if (point.Winner == Player1)
                {
                    Player2.RecordUnforcedError();
                }
                else
                {
                    Player1.RecordUnforcedError();
                }
                break;

            case PointOutcome.DoubleFault:
                if (point.Winner == Player1)
                {
                    Player2.RecordDoubleFault();
                }
                else
                {
                    Player1.RecordDoubleFault();
                }
                break;
        }
    }
    /// <summary>
    /// Checks whether the game is currently in deuce.
    /// </summary>
    private void CheckDeuce()
    {
        if (Player1Points >= 3 &&
            Player2Points >= 3 &&
            Player1Points == Player2Points)
        {
            IsDeuce = true;
            AdvantagePlayer = null;
        }
    }

    /// <summary>
    /// Checks whether a player has advantage.
    /// </summary>
    private void CheckAdvantage()
    {
        if (Player1Points >= 4 &&
            Player1Points - Player2Points == 1)
        {
            IsDeuce = false;
            AdvantagePlayer = Player1;
        }
        else if (Player2Points >= 4 &&
                Player2Points - Player1Points == 1)
        {
            IsDeuce = false;
            AdvantagePlayer = Player2;
        }
    }

    private void CheckWinner()
    {
        if (Player1Points >= 4 &&
            Player1Points - Player2Points >= 2)
        {
            Winner = Player1;

            IsDeuce = false;
            AdvantagePlayer = null;
        }

        if (Player2Points >= 4 &&
            Player2Points - Player1Points >= 2)
        {
            Winner = Player2;

            IsDeuce = false;
            AdvantagePlayer = null;
        }
    }
}
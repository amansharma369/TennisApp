using TennisScoreApi.Models.Enums;

namespace TennisScoreApi.Models.Entities;

/// <summary>
/// Represents a single point played during a tennis game.
/// A point records who served, who won, and how the point was won.
/// </summary>
public class Point
{
    /// <summary>
    /// Unique identifier for the point.
    /// </summary>
    public int PointId { get; private set; }

    /// <summary>
    /// Player who served the point.
    /// </summary>
    public Player Server { get; private set; }

    /// <summary>
    /// Player who won the point.
    /// </summary>
    public Player Winner { get; private set; }

    /// <summary>
    /// Indicates how the point was won
    /// (Ace, Winner, Service Winner, Double Fault, etc.).
    /// </summary>
    public PointOutcome Outcome { get; private set; }

    /// <summary>
    /// Time when the point was recorded.
    /// </summary>
    public DateTime TimeStamp { get; private set; }

    /// <summary>
    /// Creates a point with the required information.
    /// A point cannot exist without a server, winner, and outcome.
    /// </summary>
    public Point(
        Player server,
        Player winner,
        PointOutcome outcome)
    {
        Server = server;
        Winner = winner;
        Outcome = outcome;
        TimeStamp = DateTime.UtcNow;
    }
    private Point()
    {
    }
}
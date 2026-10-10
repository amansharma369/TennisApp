namespace TennisScoreApi.Models.Entities;

public class Statistics
{
    public int Aces { get; private set;}
    public int ServiceWinners { get; private set;}
    public int Winners { get; private set; }
    public int ForcedErrors { get; private set; }
    public int UnforcedErrors { get; private set; }
    public int DoubleFaults { get; private set; }

    public int TotalPointsWon {get; private set; }

    /// <summary>
    /// Total number of aces served by the player.
    /// </summary>
    /// <summary>
    /// Increments the ace count when the player serves an ace.
    /// </summary>
    public void RecordAce()
    {
        Aces++;
    }

    /// <summary>
    /// Increments the service winner count when the player hits a service winner.
    /// </summary>
    public void RecordServiceWinner()
    {
        ServiceWinners++;
    }

    /// <summary>
    /// Increments the winner count when the player hits a winner.
    /// </summary>
    public void RecordWinner()
    {
        Winners++;
    }

    /// <summary>
    /// Increments the forced error count when the player forces an error from the opponent.
    /// </summary>
    public void RecordForcedError()
    {
        ForcedErrors++;
    }

    /// <summary>
    /// Increments the unforced error count when the player makes an unforced error.
    /// </summary>
    public void RecordUnforcedError()  
    {
        UnforcedErrors++;
    }   

    /// <summary>
    /// Increments the double fault count when the player commits a double fault.
    /// </summary>
    public void RecordDoubleFault()
    {
        DoubleFaults++;
    }


}
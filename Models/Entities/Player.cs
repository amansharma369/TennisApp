namespace TennisScoreApi.Models.Entities;

public class Player
{
    public string Name { get; private set; }
    public int PlayerId { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string Country { get; private set; }

    public Statistics Statistics {get; private set;}

    public Player( string name, DateTime dateOfBirth, string country)
    {
        Name = name;
        DateOfBirth = dateOfBirth;
        Country = country;

        Statistics = new Statistics();
    }
    private Player()
    {
        Statistics = new Statistics();
    }

    /// <summary>
    /// Records an ace for the player.
    /// </summary>
    public void RecordAce()
    {
        Statistics.RecordAce();
    }

    /// <summary>
    /// Records a winner for the player.
    /// </summary>
    public void RecordWinner()
    {
        Statistics.RecordWinner();
    }

    /// <summary>
    /// Records a double fault for the player.
    /// </summary>
    public void RecordDoubleFault()
    {
        Statistics.RecordDoubleFault();
    }

    /// <summary>
    /// Records an unforced error for the player.
    /// </summary>
    public void RecordUnforcedError()
    {
        Statistics.RecordUnforcedError();
    }

    /// <summary>
    /// Records a forced error for the player.
    /// </summary>
    public void RecordForcedError()
    {
        Statistics.RecordForcedError();
    }

    /// <summary>
    /// Records a service winner for the player.
    /// </summary>
    public void RecordServiceWinner()
    {
        Statistics.RecordServiceWinner();
    }
}
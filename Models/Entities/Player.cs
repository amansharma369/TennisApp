namespace TennisScoreApi.Models.Entities;

public class Player
{
    public string Name { get; private set; }
    public int PlayerId { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string Country { get; private set; }

    public Statistics Statistics {get; private set;}

    public Player(string name, int playerId, DateTime dateOfBirth, string country)
    {
        Name = name;
        PlayerId = playerId;
        DateOfBirth = dateOfBirth;
        Country = country;

        Statistics = new Statistics();
    }
}
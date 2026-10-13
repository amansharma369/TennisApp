using TennisScoreApi.Factories.Interfaces;
using TennisScoreApi.Models.Entities;

namespace TennisScoreApi.Factories;

/// <summary>
/// Responsible for creating valid Player objects.
/// </summary>
public class PlayerFactory : IPlayerFactory
{
    public Player CreatePlayer(
        string name,
        int playerId,
        string country)
    {
        return new Player(
            name,
            playerId,
            DateTime.Now,
            country);
    }
}

using TennisScoreApi.Models.Entities;

namespace TennisScoreApi.Factories.Interfaces;

/// <summary>
/// Defines the contract for creating Player objects.
/// </summary>
public interface IPlayerFactory
{
    Player CreatePlayer(
    string name,
    string country);
}
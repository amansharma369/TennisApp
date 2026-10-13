using TennisScoreApi.Models.Entities;

namespace TennisScoreApi.Services.Interfaces;

public interface IMatchService
{
    // Creates a match asynchronously
    // Task CreateMatchAsync(Match match);

    Task<Match> CreateNewMatchAsync(
    string player1Name,
    string player2Name);

    // Gets all matches asynchronously
    Task<List<Match>> GetAllMatchesAsync();
}
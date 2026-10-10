using TennisScoreApi.Models;

namespace TennisScoreApi.Services.Interfaces;

public interface IMatchService
{
    // Creates a match asynchronously
    Task CreateMatchAsync(Match match);

    // Gets all matches asynchronously
    Task<List<Match>> GetAllMatchesAsync();
}
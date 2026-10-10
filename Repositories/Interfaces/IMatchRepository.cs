using TennisScoreApi.Models;

namespace TennisScoreApi.Repositories.Interfaces;

public interface IMatchRepository
{
    // Creates a match asynchronously added the Task return type to the method signature and word+Async 
    Task AddMatchAsync(Match match);

    // Gets all matches asynchronously
    Task<List<Match>> GetMatchesAsync();
}
using TennisScoreApi.Models;
using TennisScoreApi.Repositories.Interfaces;
using TennisScoreApi.Services.Interfaces;

namespace TennisScoreApi.Services;

public class MatchService : IMatchService
{
    private readonly IMatchRepository _repository;

    public MatchService(IMatchRepository repository)
    {
        _repository = repository;
        Console.WriteLine("Service Hit");
    }

    // Creates a match asynchronously
    public async Task CreateMatchAsync(Match match)
    {
        await _repository.AddMatchAsync(match);
    }

    // Gets all matches asynchronously
    public async Task<List<Match>> GetAllMatchesAsync()
    {
        return await _repository.GetMatchesAsync();
    }
}
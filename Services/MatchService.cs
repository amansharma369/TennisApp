// using TennisScoreApi.Models;
// using TennisScoreApi.Factories;
using TennisScoreApi.Factories.Interfaces;
using TennisScoreApi.Models.Entities;
using TennisScoreApi.Repositories.Interfaces;
using TennisScoreApi.Services.Interfaces;

namespace TennisScoreApi.Services;

public class MatchService : IMatchService
{
    private readonly IMatchRepository _repository;
    private readonly IPlayerFactory _playerFactory;

    public MatchService(
        IMatchRepository repository,
        IPlayerFactory playerFactory)
    {
        _repository = repository;
        _playerFactory = playerFactory;
    }

    // Creates a match asynchronously
    // public async Task CreateMatchAsync(Match match)
    // {
    //     await _repository.AddMatchAsync(match);
    // }

    // Gets all matches asynchronously
    public async Task<List<Match>> GetAllMatchesAsync()
    {
        return await _repository.GetMatchesAsync();
    }

    public async Task<Match> CreateNewMatchAsync(string player1Name, string player2Name)
    {
        var player1 = _playerFactory.CreatePlayer(
        player1Name,
        1,
        "India");

        var player2 =_playerFactory.CreatePlayer(
        player2Name,
        2,
        "India");

        var match = new Match(
            1,
            player1,
            player2,
            player1);

        await _repository.AddMatchAsync(match);

        return match;
    }
}
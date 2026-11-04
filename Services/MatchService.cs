// using TennisScoreApi.Models;
// using TennisScoreApi.Factories;
using TennisScoreApi.Factories.Interfaces;
using TennisScoreApi.Models.Entities;
using TennisScoreApi.Models.Enums;
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

    // Gets a match by Id asynchronously
    public async Task<Match?> GetMatchByIdAsync(int matchId)
    {
        return await _repository.GetMatchByIdAsync(matchId);
    }

    public async Task<Match> CreateNewMatchAsync(string player1Name, string player2Name)
    {
        // Validation:
        // Player1 name cannot be empty.
        if (string.IsNullOrWhiteSpace(player1Name))
        {
            throw new InvalidOperationException(
                "Player1 name is required.");
        }

        // Validation:
        // Player2 name cannot be empty.
        if (string.IsNullOrWhiteSpace(player2Name))
        {
            throw new InvalidOperationException(
                "Player2 name is required.");
        }

        // Validation:
        // A player cannot play against themselves.
        if (player1Name.Equals(
                player2Name,
                StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                "Players must have different names.");
        }
        var player1 =
        _playerFactory.CreatePlayer(
        player1Name,
        "India");

    var player2 =
        _playerFactory.CreatePlayer(
            player2Name,
            "India");

    var match = new Match(
        player1,
        player2,
        player1);

        await _repository.AddMatchAsync(match);

        return match;
    }

    public async Task RecordPointAsync(
    int matchId,
    int winnerPlayerId,
    PointOutcome outcome)
    {
        var match =
            await _repository.GetMatchByIdAsync(matchId);

        if (match == null)
        {
            throw new InvalidOperationException(
                $"Match {matchId} not found.");
        }

        // Validation:
        // Winner must belong to the current match.
        if (winnerPlayerId != match.Player1.PlayerId &&
            winnerPlayerId != match.Player2.PlayerId)
        {
            throw new InvalidOperationException(
                "Winner player does not belong to this match.");
        }

        if (match.Winner != null)
        {
            throw new InvalidOperationException(
                "Match is already completed.");
        }

        var currentSet =
            match.Sets.Last();

        var winner =
            winnerPlayerId == match.Player1.PlayerId
                ? match.Player1
                : match.Player2;

        if (currentSet.IsTiebreak)
        {

            currentSet.AwardTieBreakPoint(winner);

            if (currentSet.Winner != null)
            {
                match.AddSet(currentSet);

                if (match.Winner == null)
                {
                    var nextSet = new Set(
                        match.Player1,
                        match.Player2);

                    var firstGame = new Game(
                        match.Player1,
                        match.Player2,
                        match.CurrentServer);

                    nextSet.Games.Add(firstGame);

                    match.Sets.Add(nextSet);
                }
            }

            await _repository.SaveChangesAsync();
            return;
        }


        var currentGame =
            currentSet.Games.Last();


        var point = new Point(
            match.CurrentServer,
            winner,
            outcome);

        currentGame.AwardPoint(point);

        // Game completed
        if (currentGame.Winner != null)
        {
            currentSet.AddGame(currentGame);

            // Set completed
            if (currentSet.Winner != null)
            {
                match.AddSet(currentSet);

                // Match completed
                if (match.Winner == null)
                {
                    var nextSet = new Set(
                        match.Player1,
                        match.Player2);

                    var firstGame = new Game(
                        match.Player1,
                        match.Player2,
                        match.CurrentServer);

                    nextSet.Games.Add(firstGame);

                    match.Sets.Add(nextSet);
                }
            }
            else
            {
                var nextGame = new Game(
                    match.Player1,
                    match.Player2,
                    match.CurrentServer);

                currentSet.Games.Add(nextGame);
            }
        }

        await _repository.SaveChangesAsync();
    }

}
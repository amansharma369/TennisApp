using TennisScoreApi.Models.Entities;
using TennisScoreApi.Models.Enums;

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

    // Gets a match by Id asynchronously
    Task<Match?> GetMatchByIdAsync(int matchId);

    // Records a point in a match asynchronously
    Task RecordPointAsync(
    int matchId,
    int winnerPlayerId,
    PointOutcome outcome);
}
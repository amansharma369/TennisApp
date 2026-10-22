using TennisScoreApi.DTOs.Responses;
using TennisScoreApi.Models.Entities;

namespace TennisScoreApi.Mappers;

/// <summary>
/// Responsible for converting Match entities
/// into MatchResponse DTOs.
/// </summary>
public static class MatchMapper
{
    /// <summary>
    /// Converts a Match entity into a MatchResponse DTO.
    /// </summary>
    public static MatchResponse ToResponse(Match match)
    {
        return new MatchResponse
        {
            MatchId = match.MatchId,
            Player1Name = match.Player1.Name,
            Player2Name = match.Player2.Name,
            Status = match.Status.ToString()
        };
    }
}
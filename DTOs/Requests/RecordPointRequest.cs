namespace TennisScoreApi.DTOs.Requests;

using TennisScoreApi.Models.Enums;

public class RecordPointRequest
{
    public int WinnerPlayerId { get; set; }

    public PointOutcome Outcome { get; set; }
}
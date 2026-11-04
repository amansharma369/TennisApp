using System.ComponentModel.DataAnnotations;
using TennisScoreApi.Models.Enums;

namespace TennisScoreApi.DTOs.Requests;

/// <summary>
/// Request used to record a point.
/// </summary>
public class RecordPointRequest
{
    /// <summary>
    /// Must be a valid positive player id.
    /// </summary>
    [Range(
        1,
        int.MaxValue,
        ErrorMessage =
            "WinnerPlayerId must be greater than zero.")]
    public int WinnerPlayerId { get; set; }

    /// <summary>
    /// Point outcome.
    /// </summary>
    [Required]
    public PointOutcome Outcome { get; set; }
}
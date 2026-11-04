using System.ComponentModel.DataAnnotations;

namespace TennisScoreApi.DTOs.Requests;

/// <summary>
/// Request used to create a new tennis match.
/// </summary>
public class CreateMatchRequest
{
    /// <summary>
    /// Name of the first player.
    /// </summary>
    [Required(
        ErrorMessage = "Player1 name is required.")]
    [StringLength(
        50,
        ErrorMessage =
            "Player1 name cannot exceed 50 characters.")]
    public string Player1Name { get; set; } = string.Empty;


    /// <summary>
    /// Name of the second player.
    /// </summary>
    [Required(
        ErrorMessage = "Player2 name is required.")]
    [StringLength(
        50,
        ErrorMessage =
            "Player2 name cannot exceed 50 characters.")]
    public string Player2Name { get; set; } = string.Empty;
}
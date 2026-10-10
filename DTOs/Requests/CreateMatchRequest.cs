using System.ComponentModel.DataAnnotations;

namespace TennisScoreApi.DTOs.Requests;

public class CreateMatchRequest
{
    // Player1 is mandatory
    [Required(ErrorMessage = "Player1 is required")]
    [StringLength(100, ErrorMessage = "Player1 cannot exceed 100 characters")]
    public string Player1 { get; set; } = string.Empty;

    // Player2 is mandatory
    [Required(ErrorMessage = "Player2 is required")]
    [StringLength(100, ErrorMessage = "Player2 cannot exceed 100 characters")]
    public string Player2 { get; set; } = string.Empty;

    // Status is mandatory
    [Required(ErrorMessage = "Status is required")]
    [StringLength(50, ErrorMessage = "Status cannot exceed 50 characters")]
    public string Status { get; set; } = string.Empty;
}
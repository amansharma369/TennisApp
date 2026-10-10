using Microsoft.AspNetCore.Mvc;
using TennisScoreApi.Models;
using TennisScoreApi.Services.Interfaces;
using TennisScoreApi.DTOs.Requests;
using TennisScoreApi.DTOs.Responses;
using TennisScoreApi.Common;


namespace TennisScoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _service;

    // Logger for this controller
    private readonly ILogger<MatchController> _logger;

    public MatchController(
        IMatchService service,
        ILogger<MatchController> logger)
    {
        _service = service;

        _logger = logger;
    }

    // [HttpPost]
    // public IActionResult CreateMatch(Match match)
    // {
    //     Console.WriteLine("Controller Hit");
    //     _service.CreateMatch(match);

    //     return Ok(match);
    // }
[HttpPost]
public async Task<IActionResult> CreateMatch(CreateMatchRequest request)
{
    _logger.LogInformation(
    "Creating match between {Player1} and {Player2}",
    request.Player1,
    request.Player2);

    // Convert DTO into Entity
    var match = new Match
    {
        Player1 = request.Player1,
        Player2 = request.Player2,
        Status = request.Status
    };

    // Pass entity to service
    await _service.CreateMatchAsync(match);

    // Convert entity into response DTO
    var response = new MatchResponse
    {
        MatchId = match.MatchId,
        Player1 = match.Player1,
        Player2 = match.Player2,
        Status = match.Status
    };

    return Ok(
    new ApiResponse<MatchResponse>
    {
        Success = true,
        Message = "Match created successfully",
        Data = response
    });
}

    [HttpGet]
    public async Task<IActionResult> GetMatches()
    {
        _logger.LogInformation("Fetching all matches from the database");
        var matches = await _service.GetAllMatchesAsync();

        return Ok(
    new ApiResponse<List<Match>>
    {
        Success = true,
        Message = "Matches retrieved successfully",
        Data = matches
    });
    }
    // Test method for exception handling middleware
    // [HttpGet]
    // public async Task<IActionResult> GetMatches1()
    // {
    //     throw new Exception("Test Exception");
    // }
}

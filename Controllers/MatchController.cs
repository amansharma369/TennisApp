using Microsoft.AspNetCore.Mvc;
using TennisScoreApi.DTOs.Requests;
using TennisScoreApi.DTOs.Responses;
using TennisScoreApi.Mappers;
using TennisScoreApi.Services.Interfaces;

namespace TennisScoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatchController : ControllerBase
{
    private readonly IMatchService _matchService;

    public MatchController(
        IMatchService matchService)
    {
        _matchService = matchService;
    }

    [HttpPost]
    public async Task<ActionResult<MatchResponse>> CreateMatch(
        CreateMatchRequest request)
    {
        var match =
            await _matchService.CreateNewMatchAsync(
                request.Player1Name,
                request.Player2Name);

        var response =
            MatchMapper.ToResponse(match);

        return Ok(response);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<MatchResponse>> GetMatchById(int id)
    {
        var match =
            await _matchService.GetMatchByIdAsync(id);

        if (match == null)
        {
            return NotFound();
        }

        return Ok(MatchMapper.ToResponse(match));
    }


}
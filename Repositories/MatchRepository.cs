// Provides LINQ methods like ToList()
using Microsoft.EntityFrameworkCore;

// Imports TennisDbContext
using TennisScoreApi.Data;

// Imports Match model
using TennisScoreApi.Models.Entities;

// Imports Repository interface
using TennisScoreApi.Repositories.Interfaces;

namespace TennisScoreApi.Repositories;

public class MatchRepository : IMatchRepository
{
    // Database context used to communicate with SQL Server
    private readonly TennisDbContext _context;

    // Constructor Injection
    // ASP.NET automatically provides TennisDbContext
    public MatchRepository(TennisDbContext context)
    {
        _context = context;
    }


    // Creates a match in the database asynchronously
    public async Task AddMatchAsync(Match match)
    {
        // Adds entity to EF change tracker
        await _context.Matches.AddAsync(match);

        // Saves changes to SQL Server
        await _context.SaveChangesAsync();
    }

    // Reads all matches from SQL Server asynchronously
    public async Task<List<Match>> GetMatchesAsync()
    {
        return await _context.Matches.ToListAsync();
    }

    public async Task<Match?> GetMatchByIdAsync(int matchId)
    {
        return await _context.Matches
        .Include(m => m.Player1)
        .Include(m => m.Player2)
        .FirstOrDefaultAsync(m => m.MatchId == matchId);
    }
}
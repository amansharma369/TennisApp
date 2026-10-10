using Microsoft.EntityFrameworkCore;
using TennisScoreApi.Models;

namespace TennisScoreApi.Data;

public class TennisDbContext : DbContext
{
    public TennisDbContext(DbContextOptions<TennisDbContext> options)
        : base(options)
    {
    }

    public DbSet<Match> Matches { get; set; }
}
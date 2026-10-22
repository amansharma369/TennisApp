using Microsoft.EntityFrameworkCore;
using TennisScoreApi.Models.Entities;

namespace TennisScoreApi.Data;

public class TennisDbContext : DbContext
{
    public TennisDbContext(DbContextOptions<TennisDbContext> options)
        : base(options)
    {
    }

    public DbSet<Match> Matches { get; set; }

    public DbSet<Set> Sets { get; set; }

    public DbSet<Game> Games { get; set; }

    public DbSet<Point> Points { get; set; }

    public DbSet<Player> Players { get; set; }

    public DbSet<Statistics> Statistics { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Match>()
            .HasOne(m => m.Player1)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Match>()
            .HasOne(m => m.Player2)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Match>()
            .HasOne(m => m.CurrentServer)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Match>()
            .HasOne(m => m.Winner)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Set>()
    .HasOne(s => s.Player1)
    .WithMany()
    .OnDelete(DeleteBehavior.NoAction);

modelBuilder.Entity<Set>()
    .HasOne(s => s.Player2)
    .WithMany()
    .OnDelete(DeleteBehavior.NoAction);

modelBuilder.Entity<Set>()
    .HasOne(s => s.Winner)
    .WithMany()
    .OnDelete(DeleteBehavior.NoAction);

    modelBuilder.Entity<Game>()
    .HasOne(g => g.Player1)
    .WithMany()
    .OnDelete(DeleteBehavior.NoAction);

modelBuilder.Entity<Game>()
    .HasOne(g => g.Player2)
    .WithMany()
    .OnDelete(DeleteBehavior.NoAction);

modelBuilder.Entity<Game>()
    .HasOne(g => g.Server)
    .WithMany()
    .OnDelete(DeleteBehavior.NoAction);

modelBuilder.Entity<Game>()
    .HasOne(g => g.Winner)
    .WithMany()
    .OnDelete(DeleteBehavior.NoAction);

    modelBuilder.Entity<Point>()
    .HasOne(p => p.Server)
    .WithMany()
    .OnDelete(DeleteBehavior.NoAction);

modelBuilder.Entity<Point>()
    .HasOne(p => p.Winner)
    .WithMany()
    .OnDelete(DeleteBehavior.NoAction);
    }
}
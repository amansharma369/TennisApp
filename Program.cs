using TennisScoreApi.Repositories;
using TennisScoreApi.Repositories.Interfaces;
using TennisScoreApi.Services;
using TennisScoreApi.Services.Interfaces;
// Provides Entity Framework Core functionality
using Microsoft.EntityFrameworkCore;
using TennisScoreApi.Data;
using TennisScoreApi.Middleware;
using TennisScoreApi.Models.Entities;
using TennisScoreApi.Models.Enums;
using TennisScoreApi.Factories;
using TennisScoreApi.Factories.Interfaces;



// Imports our DbContext

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Registers TennisDbContext in Dependency Injection
builder.Services.AddDbContext<TennisDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<IMatchService, MatchService>();
builder.Services.AddScoped<IPlayerFactory, PlayerFactory>();

var app = builder.Build();

app.UseHttpsRedirection();

// Global exception handling middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();
// Player player1 = new Player("Aman", 1, new DateTime(1990, 1, 1), "USA");
// Player player2 = new Player("John", 2, new DateTime(1992, 5, 15), "UK");

// Console.WriteLine();
// Console.WriteLine("===== END TO END MATCH TEST =====");

// var match = new Match(
//     1,
//     player1,
//     player2,
//     player1);

// // ---------- SET 1 ----------
// var set1 = new Set(
//     1,
//     player1,
//     player2);

// for (int i = 1; i <= 6; i++)
// {
//     var game = new Game(
//         i,
//         player1,
//         player2,
//         player1);

//     // Simulate player1 winning the game
//     for (int p = 1; p <= 4; p++)
//     {
//         game.AwardPoint(
//             new Point(
//                 p,
//                 player1,
//                 player1,
//                 PointOutcome.Winner,
//                 DateTime.Now));
//     }

//     set1.AddGame(game);
// }

// match.AddSet(set1);

// // ---------- SET 2 ----------
// var set2 = new Set(
//     2,
//     player1,
//     player2);

// for (int i = 1; i <= 6; i++)
// {
//     var game = new Game(
//         i,
//         player1,
//         player2,
//         player1);

//     for (int p = 1; p <= 4; p++)
//     {
//         game.AwardPoint(
//             new Point(
//                 p,
//                 player1,
//                 player1,
//                 PointOutcome.Winner,
//                 DateTime.Now));
//     }

//     set2.AddGame(game);
// }

// match.AddSet(set2);

// Console.WriteLine($"Player1 Sets Won: {match.Player1SetsWon}");
// Console.WriteLine($"Player2 Sets Won: {match.Player2SetsWon}");
// Console.WriteLine($"Match Status: {match.Status}");
// Console.WriteLine($"Match Winner: {match.Winner?.Name}");


app.Run();


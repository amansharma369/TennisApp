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



// Imports our DbContext

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Registers TennisDbContext in Dependency Injection
builder.Services.AddDbContext<TennisDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<IMatchService, MatchService>();

var app = builder.Build();

app.UseHttpsRedirection();

// Global exception handling middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();


app.Run();


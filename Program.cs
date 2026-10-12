// using TennisScoreApi.Repositories;
// using TennisScoreApi.Repositories.Interfaces;
// using TennisScoreApi.Services;
// using TennisScoreApi.Services.Interfaces;

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();
// builder.Services.AddControllers();

// builder.Services.AddScoped<IMatchRepository, MatchRepository>();

// builder.Services.AddScoped<IMatchService, MatchService>();

// builder.Services.AddEndpointsApiExplorer();

// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

// app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast");

// app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }

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


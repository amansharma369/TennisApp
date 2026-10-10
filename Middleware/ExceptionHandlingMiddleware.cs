using System.Text.Json;

namespace TennisScoreApi.Middleware;

public class ExceptionHandlingMiddleware
{
    // Reference to next middleware in pipeline
    private readonly RequestDelegate _next;

    // Logger used for error tracking
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Continue request pipeline
            // Continue to Controller
            // Continue to Service
            // Continue to Repository
            await _next(context);
        }
        catch (Exception ex)
        {
            // Log exception
            _logger.LogError(
                ex,
                "An unhandled exception occurred.");

            context.Response.StatusCode = 500;

            context.Response.ContentType = "application/json";

            var response = new
            {
                Success = false,
                Message = "An unexpected error occurred."
            };

            var jsonResponse =
                JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
using System.Text.Json;
using TennisScoreApi.DTOs.Responses;

namespace TennisScoreApi.Middleware;

/// <summary>
/// Handles all unhandled exceptions
/// and converts them into standard API responses.
/// </summary>
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    private readonly ILogger<ExceptionHandlingMiddleware>
        _logger;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(
        HttpContext context)
    {
        try
        {
            await _next(context);
        }

        catch (InvalidOperationException ex)
        {
            _logger.LogWarning(ex.Message);

            context.Response.ContentType =
                "application/json";

            context.Response.StatusCode =
                StatusCodes.Status400BadRequest;

            var response =
                new ErrorResponse
                {
                    Success = false,
                    Message = ex.Message
                };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }

        catch (KeyNotFoundException ex)
        {
            _logger.LogWarning(ex.Message);

            context.Response.ContentType =
                "application/json";

            context.Response.StatusCode =
                StatusCodes.Status404NotFound;

            var response =
                new ErrorResponse
                {
                    Success = false,
                    Message = ex.Message
                };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }

        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "Unhandled exception occurred.");

            context.Response.ContentType =
                "application/json";

            context.Response.StatusCode =
                StatusCodes.Status500InternalServerError;

            var response =
                new ErrorResponse
                {
                    Success = false,
                    Message =
                        "An unexpected error occurred."
                };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }
    }
}
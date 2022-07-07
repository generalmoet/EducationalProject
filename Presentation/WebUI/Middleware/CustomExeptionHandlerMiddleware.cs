using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using Core.Application.Exceptions;

namespace WebUI.Middleware;

public class CustomExeptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public CustomExeptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandleExeptionAsync(context, e);
        }
    }

    private Task HandleExeptionAsync(HttpContext context, Exception e)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = string.Empty;

        switch (e)
        {
            case ValidationException validationException:
                code = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(validationException.Message);
                break;
            case UserNotFoundException:
                code = HttpStatusCode.NotFound;
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        if (result == string.Empty)
        {
            result = JsonSerializer.Serialize(new { error = e.Message });
        }

        context.Response.WriteAsync(result);
    }
}
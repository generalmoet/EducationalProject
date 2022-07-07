namespace WebUI.Middleware;

public static class CustomExeptionHandlerMiddlewareExtentions
{
    public static IApplicationBuilder UseCustomExeptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomExeptionHandlerMiddleware>();
    }
}
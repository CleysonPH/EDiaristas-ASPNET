using EDiaristas.Api.Common.Middlewares;

namespace EDiaristas.Config;

public static class MiddlewaresConfig
{
    public static void RegisterMiddlewares(this WebApplication app)
    {
        app.UseMiddleware<ApiExceptionHandlerMiddleware>();
    }
}
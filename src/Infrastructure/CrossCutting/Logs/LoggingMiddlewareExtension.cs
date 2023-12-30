
using Microsoft.AspNetCore.Builder;

namespace Infrastructure.CrossCutting.Logs
{
    public static class LoggingMiddlewareExtension
    {
        public static WebApplication UseLogging(this WebApplication app)
        {
            app.UseMiddleware<LoggingMiddleware>();
            return app;
        }
    }
}

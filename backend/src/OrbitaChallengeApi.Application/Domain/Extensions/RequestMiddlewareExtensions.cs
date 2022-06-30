using OrbitaChallengeApi.Application.Middlewares;

namespace OrbitaChallengeApi.Application.Domain.Extensions;

public static class RequestMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestMigrations(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MigrationMiddleware>();
    }
}

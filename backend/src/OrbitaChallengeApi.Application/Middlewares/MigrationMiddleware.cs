using OrbitaChallengeApi.Application.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace OrbitaChallengeApi.Application.Middlewares;

public class MigrationMiddleware
{
    private readonly RequestDelegate _next;
    public MigrationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext, IServiceScopeFactory serviceScope)
    {
        ApplicationContext context = serviceScope.CreateScope().ServiceProvider.GetService<ApplicationContext>()!;
        context.Database.Migrate();
        await _next(httpContext);
    }
}

using Microsoft.EntityFrameworkCore;

namespace OrbitaChallengeApi.Application.Data.Context;

public class ApplicationContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("orbita");
    }
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
}
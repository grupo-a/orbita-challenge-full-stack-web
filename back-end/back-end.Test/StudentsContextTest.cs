using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using students_db.Models;
using students_db.Repository;

public class StudentsContextTest : StudentsContext
{
    public DbSet<Student>? students;

    public StudentsContextTest(DbContextOptions<StudentsContext> options)
    : base(options)
    {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

        optionsBuilder.UseInMemoryDatabase("students_data").UseInternalServiceProvider(serviceProvider);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasKey(s => s.RA);
    }
}
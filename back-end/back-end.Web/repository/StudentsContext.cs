using Microsoft.EntityFrameworkCore;
using students_db.Models;

namespace students_db.Repository;

public class StudentsContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    // public StudentsContext(DbContextOptions<StudentsContext> options)
    // : base(options)
    // {}
    // public void ConfigureServices(IServiceCollection services)
    // {
    //     var connection = Environment.GetEnvironmentVariable("ConexaoMySql:MySqlConnectionString");

    //     services.AddDbContext<StudentsContext>(options =>
    //         options.UseMySql(connection)
    //     );

    //     services.AddMvc();
    // }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    if (!optionsBuilder.IsConfigured)
        {
            var connectionString = Environment.GetEnvironmentVariable("DOTNET_CONNECTION_STRING");

            optionsBuilder.UseMySql(
                connectionString,
                new MySqlServerVersion(new Version(8, 0, 11))
            );
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasKey(s => s.RA);
    }
}

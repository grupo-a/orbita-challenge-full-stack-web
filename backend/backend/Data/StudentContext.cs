using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> opt) : base(opt)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}

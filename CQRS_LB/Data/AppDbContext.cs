using CQRS_LB.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_LB.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }

        public DbSet<Payments> Payments { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Tests> Tests { get; set; }
    }
}

using Application.Common;
using Microsoft.EntityFrameworkCore;
using PrivatSchoolsAPI.Domain.Entities;

namespace PrivatSchoolsAPI.Infrastructure.Data

{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<Absences> Absences => Set<Absences>();
        public DbSet<Tests> Tests => Set<Tests>();
    }
}

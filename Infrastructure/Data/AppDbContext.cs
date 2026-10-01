using Application.Common;
using PrivatSchoolsAPI.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrivatSchoolsAPI.Domain.Entities;

namespace PrivatSchoolsAPI.Infrastructure.Data

{
    public class AppDbContext :  IdentityDbContext<ApplicationUser> , IAppDbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<Absences> Absences => Set<Absences>();
        public DbSet<TestResult> TestResults => Set<TestResult>();
    }
}

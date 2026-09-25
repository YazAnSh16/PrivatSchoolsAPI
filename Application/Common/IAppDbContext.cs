using Microsoft.EntityFrameworkCore;
using PrivatSchoolsAPI.Domain.Entities;

namespace Application.Common
{
    public interface IAppDbContext
    {
        DbSet<Student> Students { get; }
        DbSet<Payment> Payments { get; }
        DbSet<Absences> Absences { get; }
        DbSet<TestResult> TestResults { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
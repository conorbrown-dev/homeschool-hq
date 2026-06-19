using Application.Common.Persistence;
using Domain.Curriculum.Subjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public sealed class HomeschoolHqDbContext(DbContextOptions<HomeschoolHqDbContext> options)
    : DbContext(options), IUnitOfWork
{
    public DbSet<Subject> Subjects => Set<Subject>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HomeschoolHqDbContext).Assembly);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await base.SaveChangesAsync(cancellationToken);
    }
}
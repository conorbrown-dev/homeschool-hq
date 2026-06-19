using Domain.Curriculum.Subjects;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Curriculum.Subjects;

public sealed class EfSubjectRepository(HomeschoolHqDbContext dbContext) : ISubjectRepository
{
    public Task<bool> ExistsByNameAsync(SubjectName name, CancellationToken cancellationToken)
    {
        return dbContext.Subjects.AnyAsync(x => x.Name == name, cancellationToken);
    }

    public async Task AddAsync(Subject subject, CancellationToken cancellationToken)
    {
        await dbContext.Subjects.AddAsync(subject, cancellationToken);
    }
}
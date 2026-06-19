namespace Domain.Curriculum.Subjects;

public interface ISubjectRepository
{
    Task<bool> ExistsByNameAsync(SubjectName name, CancellationToken cancellationToken);
    Task AddAsync(Subject subject, CancellationToken cancellationToken);
}
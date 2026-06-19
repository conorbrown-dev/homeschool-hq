using Application.Common.Persistence;
using Domain.Curriculum.Subjects;
using Domain;

namespace Application.Curriculum.Subjects.CreateSubject;

public sealed class CreateSubjectCommandHandler(ISubjectRepository subjects, IUnitOfWork unitOfWork)
{
    public async Task<CreateSubjectResult> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
    {
        var name = SubjectName.Create(request.Name);
        var gradeBand = GradeBand.Create(request.GradeBand);
        var alreadyExists = await subjects.ExistsByNameAsync(name, cancellationToken);

        if (alreadyExists)
            throw new DomainException($"A subject named '{name}' already exists.");

        var subject = Subject.Create(name, gradeBand, request.Description);

        await subjects.AddAsync(subject, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateSubjectResult(
            subject.Id.Value,
            subject.Name.Value, subject.Description, subject.GradeBand.Value);
    }
}
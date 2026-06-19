using MediatR;

namespace Application.Curriculum.Subjects.CreateSubject;

public sealed record CreateSubjectCommand(string Name, string Description, string GradeBand) : IRequest<CreateSubjectResult>;
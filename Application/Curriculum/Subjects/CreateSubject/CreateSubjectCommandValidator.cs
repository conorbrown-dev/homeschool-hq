using FluentValidation;
using Domain.Curriculum.Subjects;

namespace Application.Curriculum.Subjects.CreateSubject;

public sealed class CreateSubjectCommandValidator : AbstractValidator<CreateSubjectCommand>
{
    public CreateSubjectCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(SubjectName.MaxLength);

        RuleFor(x => x.Description).MaximumLength(500);

        RuleFor(x => x.GradeBand)
            .NotEmpty();
    }
}
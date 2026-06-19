namespace Domain.Curriculum.Subjects;

public readonly record struct SubjectId(Guid Value)
{
    public static SubjectId New() => new(Guid.NewGuid());

    public static SubjectId From(Guid value)
    {
        if (value == Guid.Empty)
            throw new DomainException("Subject id cannot be empty.");

        return new SubjectId(value);
    }
}
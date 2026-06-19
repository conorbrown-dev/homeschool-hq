namespace Domain.Curriculum.Subjects;

public sealed record SubjectName
{
    public const int MaxLength = 100;
    
    public string Value { get; }

    private SubjectName(string value)
    {
        Value = value;
    }

    public static SubjectName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Subject name is required.");

        var normalized = value.Trim();

        if (normalized.Length > MaxLength)
            throw new DomainException($"Subject name cannot exceed {MaxLength} characters.");

        return new SubjectName(normalized);
    }

    public override string ToString() => Value;
}
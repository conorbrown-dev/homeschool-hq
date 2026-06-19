namespace Domain.Curriculum.Subjects;

public sealed class Subject
{
    private Subject()
    {
        // EF Core constructor
    }
    
    public SubjectId Id { get; private set; }
    public SubjectName Name { get; private set; } = null!;
    public string Description { get; private set; }
    public GradeBand GradeBand { get; private set; } = null!;
    public bool IsArchived { get; private set; }

    public static Subject Create(
        SubjectName name,
        GradeBand gradeBand,
        string description)
    {
        return new Subject
        {
            Id = SubjectId.New(),
            Name = name,
            GradeBand = gradeBand,
            Description = NormalizeDescription(description),
            IsArchived = false
        };
    }

    public void Rename(SubjectName name)
    {
        if (IsArchived)
            throw new DomainException("Archived subjects cannot be changed.");

        Name = name;
    }

    public void ChangeDescription(string description)
    {
        if (IsArchived)
            throw new DomainException("Archived subjects cannot be changed");

        Description = NormalizeDescription(description);
    }

    public void Archive()
    {
        IsArchived = true;
    }

    private static string NormalizeDescription(string description)
    {
        var normalized = description.Trim();

        if (normalized.Length > 500)
            throw new DomainException("Subject description cannot exceed 500 characters");

        return normalized;
    }
}
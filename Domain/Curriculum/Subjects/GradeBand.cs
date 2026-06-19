namespace Domain.Curriculum.Subjects;

public sealed record GradeBand
{
    public string Value { get; }

    private GradeBand(string value)
    {
        Value = value;
    }

    public static GradeBand Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Grade band is required");

        var normalized = value.Trim();

        var allowed = new[] { "Pre-K", "K", "K-2", "3-5", "6-8", "9-12", "All" };
        
        if (!allowed.Contains(normalized, StringComparer.OrdinalIgnoreCase))
            throw new DomainException($"Grade band '{value}' is not supported.");

        return new GradeBand(normalized);
    }

    public override string ToString() => Value;
}
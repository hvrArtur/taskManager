namespace TaskManager.Domain.ValueObjects;

public sealed record EntityDescription
{
    public const int MaxLength = 300;

    public string Value { get; }

    private EntityDescription(string value)
    {
        Value = value;
    }

    public static EntityDescription Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Description is required.", nameof(value));

        value = value.Trim();

        if (value.Length > MaxLength)
            throw new ArgumentOutOfRangeException(nameof(value), $"Description must be {MaxLength} characters or fewer.");

        return new EntityDescription(value);
    }

    public override string ToString() => Value;
}

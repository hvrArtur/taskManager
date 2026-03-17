namespace TaskManager.Domain.ValueObjects;

public sealed record EntityName
{
    public const int MaxLength = 30;

    public string Value { get; }

    private EntityName(string value)
    {
        Value = value;
    }

    public static EntityName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Name is required.", nameof(value));

        value = value.Trim();

        if (value.Length > MaxLength)
            throw new ArgumentOutOfRangeException(nameof(value), $"Name must be {MaxLength} characters or fewer.");

        return new EntityName(value);
    }

    public override string ToString() => Value;
}

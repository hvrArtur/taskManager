using TaskManager.Domain.ValueObjects;

namespace TaskManager.Domain.Entities;

public class Ticket
{
    public Guid Id { get; private set; }

    private EntityName _name = null!;
    public string Name
    {
        get => _name.Value;
        private set => _name = EntityName.Create(value);
    }

    private EntityDescription _description = null!;
    public string Description
    {
        get => _description.Value;
        private set => _description = EntityDescription.Create(value);
    }

    public Guid CreatorId { get; private set; }
    public User Creator { get; private set; } = null!;

    public DateTime CreatedAt { get; private set; }

    public Ticket(string name, string description, User creator)
    {
        ArgumentNullException.ThrowIfNull(creator);
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        Name = name;
        Description = description;
        Creator = creator;
        CreatorId = creator.Id;
    }

    private Ticket()
    {
    }

    public void Rename(string name)
    {
        Name = name;
    }

    public void ChangeDescription(string description)
    {
        Description = description;
    }
}

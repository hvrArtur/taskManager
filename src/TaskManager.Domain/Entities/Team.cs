using TaskManager.Domain.ValueObjects;

namespace TaskManager.Domain.Entities;

public class Team
{
    public Guid Id { get; private set; }

    private EntityName _name = null!;
    public string Name
    {
        get => _name.Value;
        private set => _name = EntityName.Create(value);
    }

    public Guid OwnerId { get; private set; }
    public User Owner { get; private set; } = null!;

    private readonly List<User> _members = [];
    public IReadOnlyCollection<User> Members => _members;

    public DateTime CreatedAt { get; private set; }

    public Team(string name, User owner)
    {
        ArgumentNullException.ThrowIfNull(owner);
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        Name = name;
        Owner = owner;
        OwnerId = owner.Id;
    }

    private Team()
    {
    }

    public bool AddMember(User user)
    {
        ArgumentNullException.ThrowIfNull(user);

        if (_members.Any(m => m.Id == user.Id))
            return false;

        _members.Add(user);
        return true;
    }

    public bool DeleteMember(User user)
    {
        ArgumentNullException.ThrowIfNull(user);

        if (user.Id == OwnerId)
            return false;

        return _members.Remove(user);
    }

    public void Rename(string name)
    {
        Name = name;
    }
}

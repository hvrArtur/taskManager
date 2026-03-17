using TaskManager.Domain.ValueObjects;

namespace TaskManager.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }

    private EntityName _nickName = null!;
    public string NickName
    {
        get => _nickName.Value;
        private set => _nickName = EntityName.Create(value);
    }

    private EntityName _firstName = null!;
    public string FirstName
    {
        get => _firstName.Value;
        private set => _firstName = EntityName.Create(value);
    }

    private EntityName _lastName = null!;
    public string LastName
    {
        get => _lastName.Value;
        private set => _lastName = EntityName.Create(value);
    }

    public DateTime CreatedAt { get; private set; }

    public User(string nickName, string firstName, string lastName)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        NickName = nickName;
        FirstName = firstName;
        LastName = lastName;
    }

    private User()
    {
    }

    public void Rename(string nickName, string firstName, string lastName)
    {
        NickName = nickName;
        FirstName = firstName;
        LastName = lastName;
    }
}

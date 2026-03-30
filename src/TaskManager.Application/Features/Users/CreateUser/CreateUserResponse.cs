namespace TaskManager.Application.Features.Users.CreateUser;

public sealed record CreateUserResponse(Guid Id, string NickName, string FirstName, string LastName, DateTime CreatedAtUtc);

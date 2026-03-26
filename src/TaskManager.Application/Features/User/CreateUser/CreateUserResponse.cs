namespace TaskManager.Application.Features.User.CreateUser;

public sealed record CreateUserResponse(Guid Id, string NickName, string FirstName, string LastName, DateTime CreatedAtUtc);

namespace TaskManager.Application.Features.Users.CreateUser;

public sealed record CreateUserCommand(string NickName, string FirstName, string LastName);

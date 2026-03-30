namespace TaskManager.Application.Features.Users.GetUser;

public sealed record GetUserResponse(Guid Id, string NickName, string FirstName, string LastName, DateTime CreatedAtUtc);

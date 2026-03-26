namespace TaskManager.Application.Features.User.GetUser;

public sealed record GetUserResponse(Guid Id, string NickName, string FirstName, string LastName, DateTime CreatedAtUtc);

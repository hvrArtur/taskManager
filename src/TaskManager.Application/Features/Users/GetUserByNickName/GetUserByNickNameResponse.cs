namespace TaskManager.Application.Features.Users.GetUserByNickName;

public sealed record GetUserByNickNameResponse(Guid Id, string NickName, string FirstName, string LastName, DateTime CreatedAtUtc);

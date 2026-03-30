namespace TaskManager.Application.Features.Users.GetUser;

public interface IGetUserQueryHandler
{
    Task<GetUserResponse> HandleAsync(GetUserQuery query, CancellationToken cancellationToken);
}

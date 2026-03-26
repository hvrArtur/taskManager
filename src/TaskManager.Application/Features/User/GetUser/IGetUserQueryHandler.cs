namespace TaskManager.Application.Features.User.GetUser;

public interface IGetUserQueryHandler
{
    Task<GetUserResponse> HandleAsync(GetUserQuery query, CancellationToken cancellationToken);
}

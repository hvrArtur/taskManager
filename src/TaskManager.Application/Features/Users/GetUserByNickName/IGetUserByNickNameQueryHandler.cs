namespace TaskManager.Application.Features.Users.GetUserByNickName;

public interface IGetUserByNickNameQueryHandler
{
    Task<GetUserByNickNameResponse> HandleAsync(GetUserByNickNameQuery query, CancellationToken cancellationToken);
}

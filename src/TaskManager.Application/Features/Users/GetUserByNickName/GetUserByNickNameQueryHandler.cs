using TaskManager.Application.Abstractions.Persistence;
using TaskManager.Application.Exceptions;

namespace TaskManager.Application.Features.Users.GetUserByNickName;

public sealed class GetUserByNickNameQueryHandler(IUserRepository userRepository) : IGetUserByNickNameQueryHandler
{
    public async Task<GetUserByNickNameResponse> HandleAsync(GetUserByNickNameQuery query, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByNickNameAsync(query.NickName, cancellationToken);
        if (user is null)
            throw new NotFoundException($"User with nick name '{query.NickName}' was not found.");

        return new GetUserByNickNameResponse(user.Id, user.NickName, user.FirstName, user.LastName, user.CreatedAt);
    }
}

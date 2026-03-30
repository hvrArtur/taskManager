using TaskManager.Application.Abstractions.Persistence;
using TaskManager.Application.Exceptions;

namespace TaskManager.Application.Features.Users.GetUser;

public sealed class GetUserQueryHandler(
    IUserRepository userRepository) : IGetUserQueryHandler
{
    public async Task<GetUserResponse> HandleAsync(GetUserQuery query, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(query.UserId, cancellationToken);
        if (user is null)
            throw new NotFoundException($"User '{query.UserId}' was not found.");

        return new GetUserResponse(user.Id, user.NickName, user.FirstName, user.LastName, user.CreatedAt);
    }
}

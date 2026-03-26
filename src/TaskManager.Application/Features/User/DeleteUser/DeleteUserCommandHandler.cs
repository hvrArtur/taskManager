using TaskManager.Application.Abstractions.Persistence;
using TaskManager.Application.Exceptions;

namespace TaskManager.Application.Features.User.DeleteUser;

public sealed class DeleteUserCommandHandler(
    IUserRepository userRepository) : IDeleteUserCommandHandler
{
    public async Task HandleAsync(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(command.UserId, cancellationToken);
        if (user is null)
            throw new NotFoundException($"User '{command.UserId}' was not found.");

        await userRepository.DeleteAsync(user, cancellationToken);
    }
}

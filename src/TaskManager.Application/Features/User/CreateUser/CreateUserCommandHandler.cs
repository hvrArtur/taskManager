using TaskManager.Application.Abstractions.Persistence;
using TaskManager.Application.Exceptions;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Features.User.CreateUser;

public sealed class CreateUserCommandHandler(
    IUserRepository userRepository) : ICreateUserCommandHandler
{
    public async Task<CreateUserResponse> HandleAsync(CreateUserCommand command, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(command.NickName))
            throw new ArgumentException("NickName is required.", nameof(command));

        if (string.IsNullOrWhiteSpace(command.FirstName))
            throw new ArgumentException("FirstName is required.", nameof(command));

        if (string.IsNullOrWhiteSpace(command.LastName))
            throw new ArgumentException("LastName is required.", nameof(command));

        var alreadyExists = await userRepository.ExistsByNickNameAsync(command.NickName, cancellationToken);
        if (alreadyExists)
            throw new ConflictException($"User with nick name '{command.NickName}' already exists.");

        var user = new TaskManager.Domain.Entities.User(command.NickName, command.FirstName, command.LastName);
        await userRepository.AddAsync(user, cancellationToken);

        return new CreateUserResponse(user.Id, user.NickName, user.FirstName, user.LastName, user.CreatedAt);
    }
}

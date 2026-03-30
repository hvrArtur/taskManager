namespace TaskManager.Application.Features.Users.CreateUser;

public interface ICreateUserCommandHandler
{
    Task<CreateUserResponse> HandleAsync(CreateUserCommand command, CancellationToken cancellationToken);
}

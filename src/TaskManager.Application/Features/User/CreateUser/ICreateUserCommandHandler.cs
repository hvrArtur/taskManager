namespace TaskManager.Application.Features.User.CreateUser;

public interface ICreateUserCommandHandler
{
    Task<CreateUserResponse> HandleAsync(CreateUserCommand command, CancellationToken cancellationToken);
}

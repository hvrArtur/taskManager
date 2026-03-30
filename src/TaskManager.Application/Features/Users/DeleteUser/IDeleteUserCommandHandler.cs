namespace TaskManager.Application.Features.Users.DeleteUser;

public interface IDeleteUserCommandHandler
{
    Task HandleAsync(DeleteUserCommand command, CancellationToken cancellationToken);
}

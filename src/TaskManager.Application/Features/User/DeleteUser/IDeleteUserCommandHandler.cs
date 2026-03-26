namespace TaskManager.Application.Features.User.DeleteUser;

public interface IDeleteUserCommandHandler
{
    Task HandleAsync(DeleteUserCommand command, CancellationToken cancellationToken);
}

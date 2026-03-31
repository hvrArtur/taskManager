namespace TaskManager.Application.Features.Teams.DeleteTeam;

public interface IDeleteTeamCommandHandler
{
    Task HandleAsync(DeleteTeamCommand command, CancellationToken cancellationToken);
}

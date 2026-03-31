namespace TaskManager.Application.Features.Teams.AddUserToTeam;

public interface IAddUserToTeamCommandHandler
{
    Task<AddUserToTeamResponse> HandleAsync(AddUserToTeamCommand command, CancellationToken cancellationToken);
}

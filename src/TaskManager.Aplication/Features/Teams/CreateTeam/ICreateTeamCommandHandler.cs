namespace TaskManager.Application.Features.Teams.CreateTeam;

public interface ICreateTeamCommandHandler
{
    Task<CreateTeamResponse> HandleAsync(CreateTeamCommand command, CancellationToken cancellationToken);
}

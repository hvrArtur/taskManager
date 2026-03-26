namespace TaskManager.Application.Features.Team.CreateTeam;

public interface ICreateTeamCommandHandler
{
    Task<CreateTeamResponse> HandleAsync(CreateTeamCommand command, CancellationToken cancellationToken);
}

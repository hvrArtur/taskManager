namespace TaskManager.Application.Features.Teams.GetTeam;

public interface IGetTeamQueryHandler
{
    Task<GetTeamResponse> HandleAsync(GetTeamQuery query, CancellationToken cancellationToken);
}

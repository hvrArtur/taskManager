namespace TaskManager.Application.Features.Team.CreateTeam;

public sealed record CreateTeamCommand(string Name, Guid OwnerId);

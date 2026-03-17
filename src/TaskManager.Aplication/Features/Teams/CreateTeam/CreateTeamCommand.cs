namespace TaskManager.Application.Features.Teams.CreateTeam;

public sealed record CreateTeamCommand(string Name, Guid OwnerId);

namespace TaskManager.Application.Features.Teams.AddUserToTeam;

public sealed record AddUserToTeamCommand(Guid TeamId, Guid UserId);

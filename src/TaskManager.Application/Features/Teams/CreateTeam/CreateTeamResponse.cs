namespace TaskManager.Application.Features.Teams.CreateTeam;

public sealed record CreateTeamResponse(Guid Id, string Name, Guid OwnerId, DateTime CreatedAtUtc);

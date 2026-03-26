namespace TaskManager.Application.Features.Team.CreateTeam;

public sealed record CreateTeamResponse(Guid Id, string Name, Guid OwnerId, DateTime CreatedAtUtc);

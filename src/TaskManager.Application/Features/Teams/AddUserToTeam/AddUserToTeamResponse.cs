namespace TaskManager.Application.Features.Teams.AddUserToTeam;

public sealed record AddUserToTeamResponse(
    Guid TeamId,
    string TeamName,
    Guid UserId,
    string UserNickName,
    int MembersCount);

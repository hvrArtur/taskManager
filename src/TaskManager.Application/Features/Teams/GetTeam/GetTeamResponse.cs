namespace TaskManager.Application.Features.Teams.GetTeam;

public sealed record GetTeamResponse(
    Guid Id,
    string Name,
    Guid OwnerId,
    string OwnerNickName,
    IReadOnlyCollection<GetTeamMemberResponse> Members,
    DateTime CreatedAtUtc);

public sealed record GetTeamMemberResponse(Guid Id, string NickName, string FirstName, string LastName);

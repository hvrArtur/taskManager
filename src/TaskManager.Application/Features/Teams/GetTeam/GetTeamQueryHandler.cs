using TaskManager.Application.Abstractions.Persistence;
using TaskManager.Application.Exceptions;

namespace TaskManager.Application.Features.Teams.GetTeam;

public sealed class GetTeamQueryHandler(ITeamRepository teamRepository) : IGetTeamQueryHandler
{
    public async Task<GetTeamResponse> HandleAsync(GetTeamQuery query, CancellationToken cancellationToken)
    {
        var team = await teamRepository.GetByIdAsync(query.TeamId, cancellationToken);
        if (team is null)
            throw new NotFoundException($"Team '{query.TeamId}' was not found.");

        var members = team.Members
            .Select(member => new GetTeamMemberResponse(member.Id, member.NickName, member.FirstName, member.LastName))
            .ToArray();

        return new GetTeamResponse(
            team.Id,
            team.Name,
            team.OwnerId,
            team.Owner.NickName,
            members,
            team.CreatedAt);
    }
}

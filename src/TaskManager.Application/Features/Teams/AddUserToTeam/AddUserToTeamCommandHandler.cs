using TaskManager.Application.Abstractions.Persistence;
using TaskManager.Application.Exceptions;

namespace TaskManager.Application.Features.Teams.AddUserToTeam;

public sealed class AddUserToTeamCommandHandler(
    ITeamRepository teamRepository,
    IUserRepository userRepository) : IAddUserToTeamCommandHandler
{
    public async Task<AddUserToTeamResponse> HandleAsync(AddUserToTeamCommand command, CancellationToken cancellationToken)
    {
        var team = await teamRepository.GetByIdAsync(command.TeamId, cancellationToken);
        if (team is null)
            throw new NotFoundException($"Team '{command.TeamId}' was not found.");

        var user = await userRepository.GetByIdAsync(command.UserId, cancellationToken);
        if (user is null)
            throw new NotFoundException($"User '{command.UserId}' was not found.");

        var wasAdded = team.AddMember(user);
        if (!wasAdded)
            throw new ConflictException($"User '{command.UserId}' is already part of team '{command.TeamId}' or is its owner.");

        await teamRepository.UpdateAsync(team, cancellationToken);

        return new AddUserToTeamResponse(
            team.Id,
            team.Name,
            user.Id,
            user.NickName,
            team.Members.Count);
    }
}

using TaskManager.Application.Abstractions.Persistence;
using TaskManager.Application.Exceptions;

namespace TaskManager.Application.Features.Teams.DeleteTeam;

public sealed class DeleteTeamCommandHandler(ITeamRepository teamRepository) : IDeleteTeamCommandHandler
{
    public async Task HandleAsync(DeleteTeamCommand command, CancellationToken cancellationToken)
    {
        var team = await teamRepository.GetByIdAsync(command.TeamId, cancellationToken);
        if (team is null)
            throw new NotFoundException($"Team '{command.TeamId}' was not found.");

        await teamRepository.DeleteAsync(team, cancellationToken);
    }
}

using TaskManager.Application.Abstractions.Persistence;
using TaskManager.Application.Exceptions;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Features.Teams.CreateTeam;

public sealed class CreateTeamCommandHandler(
    IUserRepository userRepository,
    ITeamRepository teamRepository) : ICreateTeamCommandHandler
{
    public async Task<CreateTeamResponse> HandleAsync(CreateTeamCommand command, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(command.Name))
            throw new ArgumentException("Team name is required.", nameof(command));

        var owner = await userRepository.GetByIdAsync(command.OwnerId, cancellationToken);
        if (owner is null)
            throw new NotFoundException($"Owner '{command.OwnerId}' was not found.");

        var alreadyExists = await teamRepository.ExistsByNameAsync(command.Name, cancellationToken);
        if (alreadyExists)
            throw new ConflictException($"Team with name '{command.Name}' already exists.");

        var team = new Team(command.Name, owner);
        await teamRepository.AddAsync(team, cancellationToken);

        return new CreateTeamResponse(team.Id, team.Name, team.OwnerId, team.CreatedAt);
    }
}

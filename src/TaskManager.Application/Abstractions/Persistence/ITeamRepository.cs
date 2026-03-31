using TaskManager.Domain.Entities;

namespace TaskManager.Application.Abstractions.Persistence;

public interface ITeamRepository
{
    Task<Team?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken);
    Task AddAsync(Team team, CancellationToken cancellationToken);
    Task UpdateAsync(Team team, CancellationToken cancellationToken);
    Task DeleteAsync(Team team, CancellationToken cancellationToken);
}

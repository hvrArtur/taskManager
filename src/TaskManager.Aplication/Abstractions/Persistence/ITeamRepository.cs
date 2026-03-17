using TaskManager.Domain.Entities;

namespace TaskManager.Application.Abstractions.Persistence;

public interface ITeamRepository
{
    System.Threading.Tasks.Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken);
    System.Threading.Tasks.Task AddAsync(Team team, CancellationToken cancellationToken);
}

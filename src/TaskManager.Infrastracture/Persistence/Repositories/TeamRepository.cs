using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Abstractions.Persistence;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Persistence.Repositories;

public sealed class TeamRepository(TaskManagerDbContext dbContext) : ITeamRepository
{
    public async Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await dbContext.Teams
            .AnyAsync(x => x.Name == name, cancellationToken);
    }

    public async System.Threading.Tasks.Task AddAsync(Team team, CancellationToken cancellationToken)
    {
        await dbContext.Teams.AddAsync(team, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}

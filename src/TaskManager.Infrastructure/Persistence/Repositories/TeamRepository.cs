using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Abstractions.Persistence;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Persistence.Repositories;

public sealed class TeamRepository(TaskManagerDbContext dbContext) : ITeamRepository
{
    public async Task<Team?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Teams
            .Include(x => x.Owner)
            .Include(x => x.Members)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await dbContext.Teams
            .AnyAsync(x => x.Name == name, cancellationToken);
    }

    public async Task AddAsync(Team team, CancellationToken cancellationToken)
    {
        await dbContext.Teams.AddAsync(team, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Team team, CancellationToken cancellationToken)
    {
        dbContext.Teams.Update(team);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Team team, CancellationToken cancellationToken)
    {
        dbContext.Teams.Remove(team);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}

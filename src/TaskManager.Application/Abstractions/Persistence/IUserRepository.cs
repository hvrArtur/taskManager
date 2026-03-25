using TaskManager.Domain.Entities;

namespace TaskManager.Application.Abstractions.Persistence;

public interface IUserRepository
{
    System.Threading.Tasks.Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}

using TaskManager.Domain.Entities;

namespace TaskManager.Application.Abstractions.Persistence;

public interface IUserRepository
{
    System.Threading.Tasks.Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    System.Threading.Tasks.Task AddAsync(User user, CancellationToken cancellationToken);
    System.Threading.Tasks.Task DeleteAsync(User user, CancellationToken cancellationToken);
    System.Threading.Tasks.Task<bool> ExistsByNickNameAsync(string nickName, CancellationToken cancellationToken);
}

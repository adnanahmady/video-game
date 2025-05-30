using VideoGame.Domain.Entities;

namespace VideoGame.Domain.Interfaces.Repositories;

public interface IUserRepository : IRepository<User, Guid>
{
    Task<User?> GetUserWithRoleAsync(string username);
}

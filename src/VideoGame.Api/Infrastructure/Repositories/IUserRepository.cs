using System.Linq.Expressions;

using VideoGame.Api.Core.Entities;

namespace VideoGame.Api.Infrastructure.Repositories;

public interface IUserRepository : IRepository<User, Guid>
{
    Task<User?> GetUserWithRoleAsync(string username);
}

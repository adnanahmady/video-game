using Microsoft.EntityFrameworkCore;

using VideoGame.Domain.Modules.Auth.Entities;
using VideoGame.Domain.Modules.Auth.Interfaces.Repositories;
using VideoGame.Infrastructure.Modules.Shared.Repositories;

namespace VideoGame.Infrastructure.Modules.Auth.Repositories;

public class UserRepository(DbContext context)
    : Repository<User, Guid>(context), IUserRepository
{
    private VideoGameDbContext _context => (Context as VideoGameDbContext)!;

    public async Task<User?> GetUserWithRoleAsync(string username) =>
        await _context.Users
            .Include(u => u.Role)
            .OrderBy(u => u.Username)
            .FirstOrDefaultAsync(u => u!.Username == username);
}

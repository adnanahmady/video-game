using Microsoft.EntityFrameworkCore;

using VideoGame.Domain.Entities;
using VideoGame.Domain.Interfaces.Repositories;

namespace VideoGame.Infrastructure.Repositories;

public class UserRepository(DbContext context)
    : Repository<User, Guid>(context), IUserRepository
{
    private VideoGameDbContext _context => (Context as VideoGameDbContext)!;

    public async Task<User?> GetUserWithRoleAsync(string username) =>
        await _context.Users.Include(u => u!.Role)
            .SingleOrDefaultAsync(u => u!.Username == username);
}

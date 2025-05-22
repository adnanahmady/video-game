using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure.Repositories;

namespace VideoGame.Api.Core.Repositories;

public class RoleRepository(DbContext context)
    : Repository<Role, int>(context), IRoleRepository
{
    private VideoGameDbContext _context => (context as VideoGameDbContext)!;
}

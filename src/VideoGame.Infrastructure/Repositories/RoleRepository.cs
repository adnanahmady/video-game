using Microsoft.EntityFrameworkCore;

using VideoGame.Domain.Entities;
using VideoGame.Domain.Interfaces.Repositories;

namespace VideoGame.Infrastructure.Repositories;

public class RoleRepository(DbContext context)
    : Repository<Role, int>(context), IRoleRepository
{
}

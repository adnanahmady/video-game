using Microsoft.EntityFrameworkCore;

using VideoGame.Domain.Modules.Auth.Entities;
using VideoGame.Domain.Modules.Auth.Interfaces.Repositories;
using VideoGame.Infrastructure.Modules.Shared.Repositories;

namespace VideoGame.Infrastructure.Modules.Auth.Repositories;

public class RoleRepository(DbContext context)
    : Repository<Role, int>(context), IRoleRepository
{
}

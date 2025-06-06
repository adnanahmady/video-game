using Microsoft.EntityFrameworkCore;

using VideoGame.Domain.Modules.Auth.Entities;
using VideoGame.Domain.Modules.Auth.Interfaces.Repositories;
using VideoGame.Infrastructure.Modules.Shared.Repositories;

namespace VideoGame.Infrastructure.Modules.Auth.Repositories;

public class PermissionRepository(DbContext context)
    : Repository<Permission, int>(context), IPermissionRepository
{
    private VideoGameDbContext _context => (Context as VideoGameDbContext)!;

    public async Task<Permission> FirstOrCreateByNameAsync(
        string name,
        Func<string, Permission>? fn = null)
    {
        var permission = await _context.Permissions
            .FirstOrDefaultAsync(p => p.Name == name);

        if (permission != null)
        {
            return permission;
        }

        permission = fn is null ? new Permission() { Name = name } : fn(name);
        await _context.Permissions.AddAsync(permission);
        await _context.SaveChangesAsync();

        return permission;
    }
}

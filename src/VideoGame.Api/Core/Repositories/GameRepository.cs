using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure.Repositories;

namespace VideoGame.Api.Core.Repositories;

public class GameRepository(DbContext context)
    : Repository<Game, int>(context), IGameRepository
{
    private VideoGameDbContext _context => (Context as VideoGameDbContext)!;
}

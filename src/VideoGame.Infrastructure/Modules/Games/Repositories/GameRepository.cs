using Microsoft.EntityFrameworkCore;

using VideoGame.Domain.Modules.Games.Entities;
using VideoGame.Domain.Modules.Games.Interfaces.Repositories;
using VideoGame.Infrastructure.Modules.Shared.Repositories;

namespace VideoGame.Infrastructure.Modules.Games.Repositories;

public class GameRepository(DbContext context)
    : Repository<Game, int>(context), IGameRepository
{
}

using Microsoft.EntityFrameworkCore;

using VideoGame.Domain.Entities;
using VideoGame.Domain.Interfaces.Repositories;

namespace VideoGame.Infrastructure.Repositories;

public class GameRepository(DbContext context)
    : Repository<Game, int>(context), IGameRepository
{
}

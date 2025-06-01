using VideoGame.Domain.Modules.Games.Entities;
using VideoGame.Domain.Modules.Shared.Interfaces.Repositories;

namespace VideoGame.Domain.Modules.Games.Interfaces.Repositories;

public interface IGameRepository : IRepository<Game, int>
{
}

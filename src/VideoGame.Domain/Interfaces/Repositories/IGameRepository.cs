using VideoGame.Domain.Entities;

namespace VideoGame.Domain.Interfaces.Repositories;

public interface IGameRepository : IRepository<Game, int>
{
}

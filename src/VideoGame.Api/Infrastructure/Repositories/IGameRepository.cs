using System.Linq.Expressions;

using VideoGame.Api.Core.Entities;

namespace VideoGame.Api.Infrastructure.Repositories;

public interface IGameRepository : IRepository<Game, int>
{
}

using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure.RequestForms.Games;

namespace VideoGame.Api.Infrastructure.Services.Games;

public interface ICreateGameService
{
    Task<Game> CreateAsync(CreateGameForm form);
}

using VideoGame.Application.Dtos.Games;
using VideoGame.Domain.Entities;

namespace VideoGame.Application.Interfaces.Services.Games;

public interface ICreateGameService
{
    Task<Game> CreateAsync(GameDto dto);
}

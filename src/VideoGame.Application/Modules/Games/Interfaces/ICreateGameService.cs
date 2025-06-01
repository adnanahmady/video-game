using VideoGame.Application.Modules.Games.Dtos;
using VideoGame.Domain.Modules.Games.Entities;

namespace VideoGame.Application.Modules.Games.Interfaces;

public interface ICreateGameService
{
    Task<Game> CreateAsync(GameDto dto);
}

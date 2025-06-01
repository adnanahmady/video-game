using VideoGame.Application.Modules.Games.Dtos;
using VideoGame.Application.Modules.Games.Interfaces;
using VideoGame.Domain.Modules.Games.Entities;
using VideoGame.Domain.Modules.Shared.Interfaces;

namespace VideoGame.Application.Modules.Games.Services;

public class CreateGameService(IUnitOfWork unitOfWork) : ICreateGameService
{
    public async Task<Game> CreateAsync(GameDto dto)
    {
        var game = new Game()
        {
            Title = dto.Title,
            Platform = dto.Platform,
            Developer = dto.Developer,
            Publisher = dto.Publisher
        };

        await unitOfWork.Games.AddAsync(game);
        await unitOfWork.CommitAsync();

        return game;
    }
}

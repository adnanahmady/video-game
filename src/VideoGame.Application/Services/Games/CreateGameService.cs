using VideoGame.Application.Dtos.Games;
using VideoGame.Application.Interfaces.Services.Games;
using VideoGame.Domain.Entities;
using VideoGame.Domain.Interfaces;

namespace VideoGame.Application.Services.Games;

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

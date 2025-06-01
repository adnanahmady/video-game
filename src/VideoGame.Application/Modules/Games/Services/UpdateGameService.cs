using VideoGame.Application.Modules.Games.Dtos;
using VideoGame.Application.Modules.Games.Interfaces;
using VideoGame.Domain.Modules.Games.Entities;
using VideoGame.Domain.Modules.Shared.Interfaces;

namespace VideoGame.Application.Modules.Games.Services;

public class UpdateGameService(IUnitOfWork unitOfWork) : IUpdateGameService
{
    public async Task<Game?> UpdateAsync(int id, GameDto dto)
    {
        var game = await unitOfWork.Games.FindByIdAsync(id);

        if (game is null)
        {
            return null;
        }

        return await UpdateAsync(game, dto);
    }

    public async Task<Game?> UpdateAsync(Game game, GameDto dto)
    {
        game.Title = dto.Title;
        game.Developer = dto.Developer;
        game.Platform = dto.Platform;
        game.Publisher = dto.Publisher;

        await unitOfWork.CommitAsync();

        return game;
    }
}

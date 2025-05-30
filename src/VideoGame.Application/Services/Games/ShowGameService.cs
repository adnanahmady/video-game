using VideoGame.Application.Interfaces.Services.Games;
using VideoGame.Domain.Entities;
using VideoGame.Domain.Interfaces;

namespace VideoGame.Application.Services.Games;

public class ShowGameService(IUnitOfWork unitOfWork) : IShowGameService
{
    public async Task<Game?> ShowAsync(int id)
    {
        var game = await unitOfWork.Games.FindByIdAsync(id);

        if (game is null)
        {
            return null;
        }

        return game;
    }
}

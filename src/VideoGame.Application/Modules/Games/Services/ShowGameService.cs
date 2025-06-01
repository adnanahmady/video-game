using VideoGame.Application.Modules.Games.Interfaces;
using VideoGame.Domain.Modules.Games.Entities;
using VideoGame.Domain.Modules.Shared.Interfaces;

namespace VideoGame.Application.Modules.Games.Services;

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

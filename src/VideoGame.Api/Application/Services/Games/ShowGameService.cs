using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core;
using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure;
using VideoGame.Api.Infrastructure.Services.Games;

namespace VideoGame.Api.Application.Services.Games;

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

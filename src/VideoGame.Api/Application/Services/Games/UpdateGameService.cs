using AutoMapper;

using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core;
using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure;
using VideoGame.Api.Infrastructure.RequestForms.Games;
using VideoGame.Api.Infrastructure.Services.Games;

namespace VideoGame.Api.Application.Services.Games;

public class UpdateGameService(IUnitOfWork unitOfWork, IMapper mapper) : IUpdateGameService
{
    public async Task<Game?> UpdateAsync(int id, UpdateGameForm form)
    {
        var game = await unitOfWork.Games.FindByIdAsync(id);

        if (game is null)
        {
            return null;
        }

        return await UpdateAsync(game, form);
    }

    public async Task<Game?> UpdateAsync(Game game, UpdateGameForm form)
    {
        mapper.Map(form, game);

        await unitOfWork.CommitAsync();

        return game;
    }
}

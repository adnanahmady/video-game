using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core;
using VideoGame.Api.Infrastructure;
using VideoGame.Api.Infrastructure.Services.Games;

namespace VideoGame.Api.Application.Services.Games;

public class DeleteGameService(IUnitOfWork unitOfWork) : IDeleteGameService
{
    public async Task<bool> DeleteAsync(int id)
    {
        var game = await unitOfWork.Games.FindByIdAsync(id);

        if (game is null)
        {
            return false;
        }

        unitOfWork.Games.Remove(game);
        await unitOfWork.CommitAsync();

        return true;
    }
}

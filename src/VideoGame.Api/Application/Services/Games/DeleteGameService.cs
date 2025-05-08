using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core;
using VideoGame.Api.Infrastructure.Services.Games;

namespace VideoGame.Api.Application.Services.Games;

public class DeleteGameService(VideoGameDbContext context) : IDeleteGameService
{
    public async Task<bool> DeleteAsync(int id)
    {
        var game = await context.Games.FirstOrDefaultAsync(g => g.Id == id);

        if (game is null)
        {
            return false;
        }

        context.Games.Remove(game);
        await context.SaveChangesAsync();

        return true;
    }
}

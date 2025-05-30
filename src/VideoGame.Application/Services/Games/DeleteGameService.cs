using VideoGame.Application.Interfaces.Services.Games;
using VideoGame.Domain.Interfaces;

namespace VideoGame.Application.Services.Games;

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

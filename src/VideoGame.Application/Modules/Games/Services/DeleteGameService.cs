using VideoGame.Application.Modules.Games.Interfaces;
using VideoGame.Domain.Modules.Shared.Interfaces;

namespace VideoGame.Application.Modules.Games.Services;

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

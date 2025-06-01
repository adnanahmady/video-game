using VideoGame.Application.Modules.Games.Interfaces;
using VideoGame.Domain.Modules.Games.Entities;
using VideoGame.Domain.Modules.Shared.Interfaces;

namespace VideoGame.Application.Modules.Games.Services;

public class ListGamesService(IUnitOfWork unitOfWork) : IListGamesService
{
    public async Task<ICollection<Game>> GetPaginatedAsync(int page, int pageSize) =>
        await unitOfWork.Games.GetPaginatedAsync(page, pageSize);

    public async Task<int> GetTotalAsync() => await unitOfWork.Games.CountAsync();
}

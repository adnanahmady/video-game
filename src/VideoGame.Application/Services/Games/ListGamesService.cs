using VideoGame.Application.Interfaces.Services.Games;
using VideoGame.Domain.Entities;
using VideoGame.Domain.Interfaces;

namespace VideoGame.Application.Services.Games;

public class ListGamesService(IUnitOfWork unitOfWork) : IListGamesService
{
    public async Task<ICollection<Game>> GetPaginatedAsync(int page, int pageSize) =>
        await unitOfWork.Games.GetPaginatedAsync(page, pageSize);

    public async Task<int> GetTotalAsync() => await unitOfWork.Games.CountAsync();
}

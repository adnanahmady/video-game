using Microsoft.EntityFrameworkCore;

using VideoGame.Api.Core;
using VideoGame.Api.Core.Entities;
using VideoGame.Api.Infrastructure;
using VideoGame.Api.Infrastructure.Services.Games;

namespace VideoGame.Api.Application.Services.Games;

public class ListGamesService(IUnitOfWork unitOfWork) : IListGamesService
{
    public async Task<ICollection<Game>> GetPaginatedAsync(int page, int pageSize) =>
        await unitOfWork.Games.GetPaginatedAsync(page, pageSize);

    public async Task<int> GetTotalAsync() => await unitOfWork.Games.CountAsync();
}

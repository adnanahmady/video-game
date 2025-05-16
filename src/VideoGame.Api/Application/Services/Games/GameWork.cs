using VideoGame.Api.Core;
using VideoGame.Api.Infrastructure.Services.Games;

namespace VideoGame.Api.Application.Services.Games;

public class GameWork(VideoGameDbContext context) : IGameWork
{
    public IShowGameService ShowService { get; } = new ShowGameService(context);
    public IListGamesService ListService { get; } = new ListGamesesService(context);
    public ICreateGameService CreateService { get; } = new CreateGameService(context);
    public IUpdateGameService UpdateService { get; } = new UpdateGameService(context);
    public IDeleteGameService DeleteService { get; } = new DeleteGameService(context);
}

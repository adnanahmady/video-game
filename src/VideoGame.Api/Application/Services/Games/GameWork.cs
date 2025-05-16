using AutoMapper;

using VideoGame.Api.Core;
using VideoGame.Api.Infrastructure.Services.Games;

namespace VideoGame.Api.Application.Services.Games;

public class GameWork(VideoGameDbContext context, IMapper mapper) : IGameWork
{
    public IShowGameService ShowService { get; } = new ShowGameService(context);
    public IListGamesService ListService { get; } = new ListGamesesService(context);
    public ICreateGameService CreateService { get; } = new CreateGameService(context, mapper);
    public IUpdateGameService UpdateService { get; } = new UpdateGameService(context, mapper);
    public IDeleteGameService DeleteService { get; } = new DeleteGameService(context);
}

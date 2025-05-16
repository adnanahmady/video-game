namespace VideoGame.Api.Infrastructure.Services.Games;

public interface IGameWork
{
    IShowGameService ShowService { get; }
    IListGamesService ListService { get; }
    ICreateGameService CreateService { get; }
    IUpdateGameService UpdateService { get; }
    IDeleteGameService DeleteService { get; }
}

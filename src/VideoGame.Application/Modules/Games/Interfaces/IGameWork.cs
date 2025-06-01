namespace VideoGame.Application.Modules.Games.Interfaces;

public interface IGameWork
{
    IShowGameService ShowService { get; }
    IListGamesService ListService { get; }
    ICreateGameService CreateService { get; }
    IUpdateGameService UpdateService { get; }
    IDeleteGameService DeleteService { get; }
}
